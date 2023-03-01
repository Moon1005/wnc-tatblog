using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;
        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    Fullname = "Jason Mouth",
                    UrlSlug = "jason-mouth",
                    Email = "json@gmail.com",
                    JoinedDate = new DateTime(2022, 10, 21)
                },
                new()
                {
                    Fullname = "Jessica Wonder",
                    UrlSlug = "jessica-wonder",
                    Email = "jessica665@motip.com",
                    JoinedDate = new DateTime(2020, 4, 19)
                },
                new()
                {
                    Fullname = "Jessica Wonder1",
                    UrlSlug = "jessica-wonder1",
                    Email = "jessica6651@motip.com",
                    JoinedDate = new DateTime(2020, 4, 19)
                },
                new()
                {
                    Fullname = "Jessica Wonder2",
                    UrlSlug = "jessica-wonder2",
                    Email = "jessica2665@motip.com",
                    JoinedDate = new DateTime(2020, 4, 19)
                },
                new()
                {
                    Fullname = "Jessica Wonder3",
                    UrlSlug = "jessica-wonder3",
                    Email = "jessica3665@motip.com",
                    JoinedDate = new DateTime(2020, 4, 19)
                },
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }
        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new() {Name = ".NET Core", Description = ".NET Core", UrlSlug = "dotnet-core"},
                new() {Name = "Architecture", Description = "Architecture", UrlSlug = "architecture"},
                new() {Name = "Messaging", Description = "Messaging", UrlSlug = "messaging"},
                new() {Name = "OOP", Description = "Object-Oriented Programming", UrlSlug = "oop"},
                new() {Name = "Design Patterns", Description = "Design Patterns", UrlSlug = "design-patterns"},
                new() {Name = "Design Patterns2", Description = "Design Patterns2", UrlSlug = "design-patterns2"},
                new() {Name = "Design Patterns3", Description = "Design Patterns3", UrlSlug = "design-patterns3"},
                new() {Name = "Design Patterns4", Description = "Design Patterns4", UrlSlug = "design-patterns4"},
                new() {Name = "Design Patterns5", Description = "Design Patterns5", UrlSlug = "design-patterns5"},
                new() {Name = "Design Patterns6", Description = "Design Patterns6", UrlSlug = "design-patterns6"},
            };

            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }
        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new() {Name = "Google", Description = "Google applications", UrlSlug = "google"},
                new() {Name = "ASP.NEW MVC", Description = "ASP.NEW MVC", UrlSlug = "aspdotnet-mvc"},
                new() {Name = "Razor Page", Description = "Razor Page", UrlSlug = "razor-page"},
                new() {Name = "Blazor", Description = "Blazor", UrlSlug = "blazor"},
                new() {Name = "Deep Learning", Description = "Deep Learning", UrlSlug = "deep-learning"},
                new() {Name = "Neural Network", Description = "Neural Network", UrlSlug = "neural-network"},
                new() {Name = "Neural Network2", Description = "Neural Network2", UrlSlug = "neural-network2"},
                new() {Name = "Neural Network3", Description = "Neural Network3", UrlSlug = "neural-network3"},
                new() {Name = "Neural Network4", Description = "Neural Network4", UrlSlug = "neural-network4"},
                new() {Name = "Neural Network5", Description = "Neural Network5", UrlSlug = "neural-network5"},
                new() {Name = "Neural Network6", Description = "Neural Network6", UrlSlug = "neural-network6"},
                new() {Name = "Neural Network7", Description = "Neural Network7", UrlSlug = "neural-network7"},
                new() {Name = "Neural Network8", Description = "Neural Network8", UrlSlug = "neural-network8"},
                new() {Name = "Neural Network9", Description = "Neural Network9", UrlSlug = "neural-network9"},
                new() {Name = "Neural Network10", Description = "Neural Network10", UrlSlug = "neural-network10"},
                new() {Name = "Neural Network11", Description = "Neural Network11", UrlSlug = "neural-network11"},
                new() {Name = "Neural Network12", Description = "Neural Network12", UrlSlug = "neural-network12"},
                new() {Name = "Neural Network13", Description = "Neural Network13", UrlSlug = "neural-network13"},
                new() {Name = "Neural Network14", Description = "Neural Network14", UrlSlug = "neural-network14"},
                new() {Name = "Neural Network15", Description = "Neural Network15", UrlSlug = "neural-network15"},
            };

            _dbContext.Tags.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }
        private IList<Post> AddPosts(
        IList<Author> authors,
        IList<Category> categories,
        IList<Tag> tags)
        {
            var posts = new List<Post>()
            {
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios",
                    ShortDescription = "David and friends has a great repository",
                    Description = "Here's a few great DON'T and Do examples",
                    Meta = "David and friends has a great repository",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios2",
                    ShortDescription = "David and friends has a great repository2",
                    Description = "Here's a few great DON'T and Do examples2",
                    Meta = "David and friends has a great repository2",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios2",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[1],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios3",
                    ShortDescription = "David and friends has a great repository3",
                    Description = "Here's a few great DON'T and Do examples3",
                    Meta = "David and friends has a great repository3",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios3",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[2],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios4",
                    ShortDescription = "David and friends has a great repository4",
                    Description = "Here's a few great DON'T and Do examples4",
                    Meta = "David and friends has a great repository4",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios4",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[3],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios5",
                    ShortDescription = "David and friends has a great repository5",
                    Description = "Here's a few great DON'T and Do examples5",
                    Meta = "David and friends has a great repository5",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios5",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[4],
                    Category = categories[4],
                    Tags = new List<Tag>()
                    {
                        tags[4]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios6",
                    ShortDescription = "David and friends has a great repository6",
                    Description = "Here's a few great DON'T and Do examples6",
                    Meta = "David and friends has a great repository6",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios6",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[1],
                    Category = categories[6],
                    Tags = new List<Tag>()
                    {
                        tags[16]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios7",
                    ShortDescription = "David and friends has a great repository7",
                    Description = "Here's a few great DON'T and Do examples7",
                    Meta = "David and friends has a great repository7",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios7",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[2],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[17]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios8",
                    ShortDescription = "David and friends has a great repository8",
                    Description = "Here's a few great DON'T and Do examples8",
                    Meta = "David and friends has a great repository8",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios8",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[3],
                    Category = categories[8],
                    Tags = new List<Tag>()
                    {
                        tags[18]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios9",
                    ShortDescription = "David and friends has a great repository9",
                    Description = "Here's a few great DON'T and Do examples9",
                    Meta = "David and friends has a great repository9",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[4],
                    Category = categories[9],
                    Tags = new List<Tag>()
                    {
                        tags[19]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenario10",
                    ShortDescription = "David and friends has a great repository10",
                    Description = "Here's a few great DON'T and Do examples10",
                    Meta = "David and friends has a great repository10",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios10",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios11",
                    ShortDescription = "David and friends has a great repository11",
                    Description = "Here's a few great DON'T and Do examples11",
                    Meta = "David and friends has a great repository11",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios11",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[1],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios12",
                    ShortDescription = "David and friends has a great repository12",
                    Description = "Here's a few great DON'T and Do examples12",
                    Meta = "David and friends has a great repository12",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios12",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[2],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios13",
                    ShortDescription = "David and friends has a great repository13",
                    Description = "Here's a few great DON'T and Do examples13",
                    Meta = "David and friends has a great repository13",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios13",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[3],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios14",
                    ShortDescription = "David and friends has a great repository14",
                    Description = "Here's a few great DON'T and Do examples14",
                    Meta = "David and friends has a great repository14",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios14",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[4],
                    Category = categories[4],
                    Tags = new List<Tag>()
                    {
                        tags[4]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios15",
                    ShortDescription = "David and friends has a great repository15",
                    Description = "Here's a few great DON'T and Do examples15",
                    Meta = "David and friends has a great repository15",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios15",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[5]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios16",
                    ShortDescription = "David and friends has a great repository16",
                    Description = "Here's a few great DON'T and Do examples16",
                    Meta = "David and friends has a great repository16",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios16",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[1],
                    Category = categories[6],
                    Tags = new List<Tag>()
                    {
                        tags[6]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios17",
                    ShortDescription = "David and friends has a great repository17",
                    Description = "Here's a few great DON'T and Do examples17",
                    Meta = "David and friends has a great repository17",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios17",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[2],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[7]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios18",
                    ShortDescription = "David and friends has a great repository18",
                    Description = "Here's a few great DON'T and Do examples18",
                    Meta = "David and friends has a great repository18",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios18",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[3],
                    Category = categories[8],
                    Tags = new List<Tag>()
                    {
                        tags[8]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios19",
                    ShortDescription = "David and friends has a great repository19",
                    Description = "Here's a few great DON'T and Do examples19",
                    Meta = "David and friends has a great repository19",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios19",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[4],
                    Category = categories[9],
                    Tags = new List<Tag>()
                    {
                        tags[9]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios20",
                    ShortDescription = "David and friends has a great repository20",
                    Description = "Here's a few great DON'T and Do examples20",
                    Meta = "David and friends has a great repository20",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios20",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[10]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios21",
                    ShortDescription = "David and friends has a great repository21",
                    Description = "Here's a few great DON'T and Do examples21",
                    Meta = "David and friends has a great repository21",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios21",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[11]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios22",
                    ShortDescription = "David and friends has a great repository22",
                    Description = "Here's a few great DON'T and Do examples22",
                    Meta = "David and friends has a great repository22",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios22",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[2],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[12]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios23",
                    ShortDescription = "David and friends has a great repository23",
                    Description = "Here's a few great DON'T and Do examples23",
                    Meta = "David and friends has a great repository23",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios23",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[3],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[13]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios24",
                    ShortDescription = "David and friends has a great repository24",
                    Description = "Here's a few great DON'T and Do examples24",
                    Meta = "David and friends has a great repository24",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios24",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[4],
                    Category = categories[4],
                    Tags = new List<Tag>()
                    {
                        tags[14]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios25",
                    ShortDescription = "David and friends has a great repository25",
                    Description = "Here's a few great DON'T and Do examples25",
                    Meta = "David and friends has a great repository25",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios25",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[15]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios26",
                    ShortDescription = "David and friends has a great repository26",
                    Description = "Here's a few great DON'T and Do examples26",
                    Meta = "David and friends has a great repository26",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios26",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[1],
                    Category = categories[6],
                    Tags = new List<Tag>()
                    {
                        tags[16]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios27",
                    ShortDescription = "David and friends has a great repository27",
                    Description = "Here's a few great DON'T and Do examples27",
                    Meta = "David and friends has a great repository27",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios27",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[2],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[17]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios28",
                    ShortDescription = "David and friends has a great repository28",
                    Description = "Here's a few great DON'T and Do examples28",
                    Meta = "David and friends has a great repository28",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios28",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[3],
                    Category = categories[8],
                    Tags = new List<Tag>()
                    {
                        tags[18]
                    }
                },
                new() {
                    Title = "ASP.NET Core Diagnostic Scenarios29",
                    ShortDescription = "David and friends has a great repository29",
                    Description = "Here's a few great DON'T and Do examples29",
                    Meta = "David and friends has a great repository29",
                    UrlSlug = "aspdotnet-core-diagnostic-scenarios29",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[4],
                    Category = categories[9],
                    Tags = new List<Tag>()
                    {
                        tags[19]
                    }
                },
               
                
            };

            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }
    }
}
