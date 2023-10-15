using Microsoft.AspNetCore.Identity;
using MovieLibrary.DataAccess;
using MovieLibrary.Models.Enums;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.Static;

namespace mvc.Data.DataSeed
{
    public class DataSeeding
    {
        public async static Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                try
                {
                    var actors = new List<Actor>()
                        {
                            new Actor()
                            {
                                FullName = "Рами Малек",
                                Bio = "Рами Саид Малек - американский актер. Его известность пришла благодаря роли хакера Эллиота Алдерсона в телевизионном сериале USA Network «Мистер Робот», за которую он получил премию «Эмми».",
                                Image = new Image { ImagePath = "images/test/actors/actor-Rami.webp" }
                            },
                            new Actor()
                            {
                                FullName = "Роберт Дауни мл.",
                                Bio = "Роберт Джон Дауни младший - американский актер. Его карьера характеризуется как критическим, так и популярным успехом в молодости, затем периодом проблем с веществами и юридическими трудностями, а затем новым коммерческим успехом в более поздние годы.",
                                Image = new Image { ImagePath = "images/test/actors/actor-Robert_Downey.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Мэтт Лебланк",
                                Bio = "Американский актер, получивший всемирное признание благодаря роли Джоуи Триббиани в ситкоме NBC «Друзья» и его спин-оффе «Джоуи». За работу в «Друзьях» Лебланк был номинирован на премию «Эмми» три раза. Он также сыграл вымышленную версию себя в сериале «Эпизоды» (2011-2017), за что получил «Золотой глобус» и еще четыре номинации на «Эмми». Он вместе с другим велел шоу «Top Gear» с 2016 по 2019 год. С 2016 по 2020 год он играл патриарха Адама Бернса в ситкоме CBS «Человек с планом».",
                                Image = new Image { ImagePath = "images/test/actors/actorMatt-LeBlanc-232420843.jpeg" }
                            },
                            new Actor()
                            {
                                FullName = "Марго Робби",
                                Bio = "Австралийская актриса и продюсер, известная своей работой как в блокбастерах, так и в независимых фильмах. Она получила различные награды, включая номинации на две премии «Оскар», четыре «Золотых глобуса» и пять премий Британской академии киноискусств.",
                                Image = new Image { ImagePath = "images/test/actors/actor-margot.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Том Круз",
                                Bio = "Томас Круз Мапотер IV, известный профессионально под именем Том Круз, - американский актер и продюсер. Один из самых высокооплачиваемых актеров мира, он получил различные награды, включая почетную «Пальмовую ветвь» и три «Золотых глобуса», а также номинации на четыре премии «Оскар».",
                                Image = new Image { ImagePath = "images/test/actors/tom.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Уилл Феррелл",
                                Bio = "Американский актер, комик, сценарист и продюсер. Феррелл известен своими главными ролями в комедийных фильмах и работой в качестве телевизионного продюсера. Он получил четыре награды «Эмми» и в 2011 году был удостоен Премии Марка Твена за американский юмор.",
                                Image = new Image { ImagePath = "images/test/actors/actor-will-ferrell.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Майкл Сера",
                                Bio = "Канадский актер, известный своими неуклюжими, оригинальными персонажами в комедийных фильмах о взрослении и роли Джорджа Майкла Блюта в ситкоме «Арестованное развитие». Он также известен своей ролью Брата Медвежонка в сериале «Медвежата Беренстейнов».",
                                Image = new Image { ImagePath = "images/test/actors/actor-michael.jpg" }
                            },
                            new Actor()
                            {
                                FullName = "Лиа Льюис",
                                Bio = "Лиа Льюис - американская актриса, наиболее известная своими ролями как Элли Чу в фильме Netflix «Половина» и Джорджа Фан в телесериале The CW по мотивам романов о Нэнси Дрю. Она также озвучивает главную роль Эмбер Люмен в анимационном фильме Pixar «Элементаль».",
                                Image = new Image { ImagePath = "images/test/actors/Leah_Lewis.webp" }
                            },
                            new Actor()
                            {
                                FullName = "Райан Томас Гослинг",
                                Bio = "Канадский актер, знаменитый как в независимом кино, так и в крупных студийных фильмах разных жанров. Его фильмы собрали по всему миру свыше 1,9 миллиарда долларов США.",
                                Image = new Image() { ImagePath = "images/test/actors/actor-ryan-gosling.webp" }
                            },
                            new Actor()
                            {
                                FullName = "Силлиан Мерфи",
                                Bio = "Ирландский актер, сделавший свой профессиональный дебют в пьесе Энда Уолша «Свиньи-дискотеки» в 1996 году, роль, которую он впоследствии повторил в экранизации 2001 года.",
                                Image = new Image { ImagePath = "images/test/actors/actor-Cillian-Murphy.jpg" }
                            },
                        };
                    if (!context!.Actors.Any())
                    {
                        await context.Actors.AddRangeAsync(actors);

                        await context.SaveChangesAsync();
                    }
                    var cinemas = new List<Cinema>()
                        {
                            new Cinema()
                            {
                                Name = "Синема парк",
                                Description = "«Формула кино»/«Синема парк» — российская сеть кинотеатров, образованная в 2017 году путём объединения сетей «Формула кино» и «Синема парк» и ставшая крупнейшей в России.",
                                Image = new Image()
                                {
                                    ImagePath = "images/test/cinemas/cinema_park.jpeg"
                                }
                            },
                        };
                    if (!context!.Cinemas.Any())
                    {
                        await context.Cinemas.AddRangeAsync(cinemas);
                        await context.SaveChangesAsync();

                    }
                    var directors = new List<Director>()
                    {
                        new Director()
                        {
                            FullName = "Алехандро Монтеверде",
                            Bio = "Хосе Алехандро Гомес Монтеверде - мексиканский кинорежиссёр. Его первый фильм, «Белла», завоевал высший приз на Торонтоском международном кинофестивале 2006 года, получив «Приз зрителей».",
                            Image = new Image() { ImagePath = "images/test/directors/gomez.webp" }
                        },
                        new Director()
                            {
                                FullName = "Грета Гервиг",
                                Bio = "Американская режиссёр, сценарист и актриса, которая первоначально привлекла внимание своей работой в нескольких фильмах мамблкора.",
                                Image = new Image() { ImagePath = "images/test/directors/greta-gerwig.jpeg" }
                            },
                        new Director()
                        {
                            FullName = "Питер Сон",
                            Bio = "Питер Сон - американский аниматор, режиссёр и актёр озвучки, наиболее известный своей работой в студии анимации Pixar. Он режиссировал короткометражный фильм «Частично облачно», а также полнометражные фильмы «Добрый динозавр» и «Элементаль». Он также озвучивал персонажей в таких фильмах, как «Рататуй», «Университет монстров» и «Световой год».",
                            Image = new Image() { ImagePath = "images/test/directors/peter.jpeg" }
                        },
                        new Director()
                        {
                            FullName = "Кристофер МакКуорри",
                            Bio = "Кристофер МакКуорри - американский режиссёр, продюсер и сценарист. Он получил премию BAFTA, Independent Spirit Award и премию «Оскар» за лучший оригинальный сценарий за нео-нуар-мистический фильм «Обыкновенные подозреваемые». Он дебютировал в качестве режиссёра криминальным триллером «Путь орудия».",
                            Image = new Image() { ImagePath = "images/test/directors/Christopher_McQuarrie.jpg" }
                        },
                        new Director()
                        {
                            FullName = "Кристофер Нолан",
                            Bio = "Кристофер Эдвард Нолан CBE - британский и американский режиссёр. Известный своими голливудскими блокбастерами с сложным сюжетом, Нолан считается одним из ведущих кинорежиссёров 21 века. Его фильмы собрали более 5 миллиардов долларов по всему миру.",
                            Image = new Image() { ImagePath = "images/test/directors/cristopher-nolan.jpeg" }
                        },
                    };
                    if (!context.Directors.Any())
                    {
                        await context.Directors.AddRangeAsync(directors);
                        await context.SaveChangesAsync();
                    }

                    var movies = new List<Movie>();
                    movies.Add(
                            new Movie()
                            {
                                Name = "Барби",
                                Description = "Барби и Кен веселятся в ярком и кажущемся идеальном мире Барбиленда. Однако, когда у них появляется шанс попасть в настоящий мир, они вскоре обнаруживают радости и опасности жизни среди людей.",
                                Price = 500M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[0].Id,
                                Cinema = cinemas[0],
                                MovieCategory = MovieCategory.Драма,
                                DirectorId = directors[0].Id,
                                Director = directors[0],
                                Image = new Image() { ImagePath = "images/test/movies/barbie.webp" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[0],
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[2]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[3]
                                    }
                                }
                            });
                    movies.Add(
                            new Movie()
                            {
                                Name = "Элементаль",
                                Description = "В городе, где живут жители огня, воды, земли и воздуха, огненная молодая женщина и спокойный парень узнают, что у них есть нечто общее.",
                                Price = 450M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[0].Id,
                                Cinema = cinemas[0],
                                MovieCategory = MovieCategory.Комедия,
                                DirectorId = directors[3].Id,
                                Director = directors[3],
                                Image = new Image() { ImagePath = "images/test/movies/elemental.jpg" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[8]
                                    }
                                }
                            });
                    movies.Add(
                            new Movie()
                            {
                                Name = "Оппенгеймер",
                                Description = "Во время Второй мировой войны генерал-лейтенант Лесли Гровс назначает физика Дж. Роберта Оппенгеймера работать над секретным проектом Манхэттен. Оппенгеймер и команда ученых проводят годы, разрабатывая и создавая атомную бомбу. Их работа увенчивается 16 июля 1945 года, когда они становятся свидетелями первого ядерного взрыва в мире, навсегда изменившего ход истории.",
                                Price = 400M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[0].Id,
                                Cinema = cinemas[0],
                                MovieCategory = MovieCategory.Драма,
                                DirectorId = directors[1].Id,
                                Director = directors[1],
                                Image = new Image() { ImagePath = "images/test/movies/film-oppen.jpeg" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[4]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[5]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[6]
                                    },
                                    new ActorMovie()
                                    {
                                        Actor = actors[7]
                                    }
                                }
                            });
                    movies.Add(
                            new Movie()
                            {
                                Name = "Миссия: невыполнима. Смертельная расплата, часть 1",
                                Description = "Итан Хант и команда МОГ должны отследить ужасное новое оружие, которое угрожает всему человечеству, если оно окажется в неправильных руках. Судьба будущего и судьба мира находятся вне зависимости от миссии, начинается смертельная гонка по всему миру. Столкнувшись с загадочным, всеобладающим врагом, Итану приходится понять, что ничто не может быть важнее миссии, даже жизни тех, кто ему больше всего дорог.",
                                Price = 300M,
                                StratDate = DateTime.UtcNow.AddDays(-10),
                                EndDate = DateTime.UtcNow.AddDays(10),
                                CinemaId = cinemas[0].Id,
                                Cinema = cinemas[0],
                                MovieCategory = MovieCategory.Экшен,
                                DirectorId = directors[2].Id,
                                Director = directors[2],
                                Image = new Image() { ImagePath = "images/test/movies/Impossible.jpg" },
                                ActorsMovies = new List<ActorMovie>()
                                {
                                    new ActorMovie()
                                    {
                                        Actor = actors[9]
                                    }
                                }
                            });
                    if (!context.Movies.Any())
                    {
                        await context.Movies.AddRangeAsync(movies);
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Seeding data error", ex);
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
                try
                {
                    if (await roleManager!.RoleExistsAsync(UserRolesValues.Admin) == false)
                    {
                        await roleManager!.CreateAsync(new IdentityRole(UserRolesValues.Admin));
                    }
                    if (await roleManager!.RoleExistsAsync(UserRolesValues.User) == false)
                    {
                        await roleManager!.CreateAsync(new IdentityRole(UserRolesValues.User));
                    }


                    // Add users
                    var adminUser = await userManager!.FindByEmailAsync("ivanov@example.com");
                    if (adminUser == null)
                    {
                        adminUser = new AppUser()
                        {
                            FirstName = "Иван",
                            LastName = "Иванов",
                            UserName = "ivanov_ivan",
                            Email = "ivanov@example.com",
                            EmailConfirmed = true,
                            PhoneNumber = "123-456-7890",
                            PhoneNumberConfirmed = true,
                            UserAddress = new UserAddress()
                            {
                                Country = "Россия",
                                City = "Москва",
                            }
                        };
                        await userManager.CreateAsync(adminUser, "Admin111@");
                        await userManager.AddToRoleAsync(adminUser, UserRolesValues.Admin);
                    }

                    var testUser = await userManager!.FindByEmailAsync("annapetrova@example.com");
                    if (testUser == null)
                    {
                        testUser = new AppUser()
                        {
                            FirstName = "Анна",
                            LastName = "Петрова",
                            UserName = "annapetrova",
                            Email = "annapetrova@example.com",
                            EmailConfirmed = true,
                            PhoneNumber = "987-654-3210",
                            PhoneNumberConfirmed = true,
                            UserAddress = new UserAddress()
                            {
                                Country = "Россия",
                                City = "Санкт-Петербург",
                            }
                        };
                        await userManager.CreateAsync(testUser, "User111@");

                        await userManager.AddToRoleAsync(testUser, UserRolesValues.User);
                    }

                    await context!.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Seeding users error", ex);
                }
            }
        }
    }
}