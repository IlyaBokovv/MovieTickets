using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess;
using MovieLibrary.DataAccess.Repository;
using MovieLibrary.Models.Models;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Services.Services
{
    public class CinemaService : RepositoryBase<Cinema>, ICinemaService
    {
        private readonly ApplicationDbContext _db;
        private readonly IImageUploadService _imageUploadService;
        private static Dictionary<char, string> transliterationTable = new Dictionary<char, string>
            {
        {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"}, {'е', "e"}, {'ё', "yo"}, {'ж', "zh"}, {'з', "z"},
        {'и', "i"}, {'й', "y"}, {'к', "k"}, {'л', "l"}, {'м', "m"}, {'н', "n"}, {'о', "o"}, {'п', "p"}, {'р', "r"},
        {'с', "s"}, {'т', "t"}, {'у', "u"}, {'ф', "f"}, {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"}, {'ш', "sh"},
        {'щ', "shch"}, {'ъ', ""}, {'ы', "y"}, {'ь', ""}, {'э', "e"}, {'ю', "yu"}, {'я', "ya"},
        {'А', "A"}, {'Б', "B"}, {'В', "V"}, {'Г', "G"}, {'Д', "D"}, {'Е', "E"}, {'Ё', "Yo"}, {'Ж', "Zh"}, {'З', "Z"},
        {'И', "I"}, {'Й', "Y"}, {'К', "K"}, {'Л', "L"}, {'М', "M"}, {'Н', "N"}, {'О', "O"}, {'П', "P"}, {'Р', "R"},
        {'С', "S"}, {'Т', "T"}, {'У', "U"}, {'Ф', "F"}, {'Х', "Kh"}, {'Ц', "Ts"}, {'Ч', "Ch"}, {'Ш', "Sh"},
        {'Щ', "Shch"}, {'Ъ', ""}, {'Ы', "Y"}, {'Ь', ""}, {'Э', "E"}, {'Ю', "Yu"}, {'Я', "Ya"}
            };

        public CinemaService(ApplicationDbContext db, IImageUploadService imageUploadService) : base(db)
        {
            _db = db;
            _imageUploadService = imageUploadService;
        }
        public async Task<Cinema> UpdateWithImageAsync(Cinema cinema)
        {
            var oldImage = await _db.Cinemas.Include(a => a.Image)
                .Where(i => i.Id == cinema.Id)
                .Select(a => a.Image)
                .FirstOrDefaultAsync();
            if (oldImage == null)
            {
                throw new InvalidOperationException("invalid cinema id");
            }
            if (cinema.Image.ImageFile == null)
            {
                cinema.ImageId = oldImage.Id;
                await UpdateAsync(cinema);
                return cinema;

            }
            _imageUploadService.Delete(oldImage.ImagePath);

            var imagePath = await _imageUploadService.UploadAsync(cinema.Image, nameof(Cinema) + ConvertToTranslit(cinema.Name!));
            cinema.Image.ImagePath = imagePath;


            await _db.Images.AddAsync(cinema.Image);
            await _db.SaveChangesAsync();

            cinema.ImageId = cinema.Image.Id;
            _db.Cinemas.Entry(cinema).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            _db.Images.Remove(oldImage);
            await _db.SaveChangesAsync();
            return cinema;
        }
        public async Task<Cinema> AddWithImageUplodaing(Cinema cinema)
        {
            var imagePath = await _imageUploadService.UploadAsync(cinema.Image, nameof(Cinema) + ConvertToTranslit(cinema.Name!));

            cinema.Image.ImagePath = imagePath;
            await _db.Cinemas.AddAsync(cinema);
            await _db.SaveChangesAsync();
            return cinema;
        }
        public async Task DeleteAsyncWithImage(Cinema cinema)
        {
            _db.Cinemas.Remove(cinema);
            if (cinema.Image != null)
            {
                _imageUploadService.Delete(cinema.Image.ImagePath);
                _db.Images.Remove(cinema.Image);
            }
            await _db.SaveChangesAsync();
        }

        public static string ConvertToTranslit(string input)
        {
            char[] inputChars = input.ToCharArray();
            List<string> outputChars = new List<string>();

            foreach (char c in inputChars)
            {
                if (transliterationTable.ContainsKey(c))
                    outputChars.Add(transliterationTable[c]);
                else
                    outputChars.Add(c.ToString());
            }

            return string.Join("", outputChars);
        }

    }
}
