using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using ExamProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using ExamProject.Domain.Entities.Abstract;

namespace ExamProject.Infrustracture.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            DateTime dateTime = DateTime.Now;
            foreach (var item in modifiedEntries)
            {
                var entity = item.Entity as BaseEntity;

                if (entity != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedDate = dateTime;
                        entity.IsActive = true;

                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedDate = dateTime;
                        entity.IsModified = true;
                    }
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>().HasData(
                        new Post
                        {
                            Id = Guid.NewGuid(),
                            AuthorName = "Matt Simon",
                            Header = "Technology Can Fix the Climate Mess—but Not Without Help",
                            PostedDate = new DateTime(2022, 04, 04),
                            CreatedDate = DateTime.Now,
                            IsActive = true,
                            Content = "THIS MORNING, THE UN’s Intergovernmental Panel on Climate Change dropped its most contentious report yet. Following previous installments on how humanity’s abuses of the land and the sea are exacerbating climate change, and how things are generally not good (although hope is not altogether lost), this one tackles the thorniest question: how we’re supposed to come together as a species to fix this mess. The assessment, which was authored by hundreds of scientists, makes it clear that humanity has the tools to fight climate change. It just lacks the political will to do it. “The jury has reached the verdict and it is damning,' said António Guterres, the secretary-general of the United Nations, during a Monday press conference announcing the findings, calling the report “a litany of broken climate promises. It is a file of shame cataloging the empty pledges that put us firmly on track toward an unlivable world.' He invoked climate catastrophes—“unprecedented heat waves, terrifying storms, widespread water shortages, the extinction of a million species of plants and animals”—and warned against those who would brush the report aside. “This is not fiction or exaggeration. It is what science tells us will result from our current energy policies,” he said. One of the report’s more sobering conclusions is that we would need to cut emissions by 43 percent by 2030 and keep warming to the Paris Agreement’s goal of 1.5 degrees Celsius.Yet countries’ current climate pledges are setting up an increase in emissions between now and then, the report’s authors conclude.We need emissions to peak by 2025, they write, but without dramatically strengthening mitigation efforts, we’re on track to see an alarming 3.2 degrees Celsius of warming by the end of the century."

                        },
                    new Post
                    {
                        Id = Guid.NewGuid(),
                        AuthorName = "BRENDA STOLYAR",
                        Header = "The Apple Watch Series 7 Is at Its Lowest Price Ever",
                        PostedDate = new DateTime(2022, 04, 04),
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Content = "TIRED OF TRACKING your workouts with your iPhone but don't want to drop a ton of cash on a shiny, new smartwatch? Well, you're in luck. The Apple Watch Series 7 (8/10, WIRED Recommends) is on sale for up to $70 off (for both sizes and models, including cellular), which means you can purchase the smartwatch for as low as $329. It frequently dips in price, but this is the cheapest we've tracked so far. If you're planning to purchase it through Amazon,we recommend you don't wait too long—the deal is only valid until April 5"
                    },
                    new Post
                    {
                        Id = Guid.NewGuid(),
                        AuthorName = "WILL BEDINGFIELD",
                        Header = "Roblox’s ‘Layered Clothing’ Is Here—but Don’t Call It an NFT",
                        PostedDate = new DateTime(2022, 04, 04),
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Content = "EVEN WHEN FASHION and video games seemed, in the popular imagination at least, polar opposite pursuits, players have always liked to dress up. Now, fashion in games isn’t just grand cosplay festivals or finding a neat mask for Link: it’s tapped into older industries, and no better demonstration of this fact is Roblox, where, for instance, a Gucci bag sold for $4,115, or 350,000 Robux, $800 more than the real thing.In fact Roblox, now played by close to 50 million people each day and the most valuable video game company in the US, is one platform where character customization, and the self - expression it affords, is fundamental to the experience.Now Roblox has created a new system that improves this customization: “layered clothing.” It has the potential to further the company's goals of being more than a game: a place—whisper it, a metaverse—for games."
                    },
                    new Post
                    {
                        Id = Guid.NewGuid(),
                        AuthorName = "WIRED STAFF",
                        Header = "WIRED’s Picks for the 15 Books You Need to Read This Summer",
                        PostedDate = new DateTime(2022, 04, 04),
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Content = "PERHAPS IT’S SOMETHING in the air, but right now it seems as though half the new books on shelves deal with the climate crisis in some way. The environment is central to at least three of the 15 books on WIRED’s latest recommendations for readers. But that’s just the start. The books on this list also cover language, Blackness, the death of facts, and dolphin handjobs. When we say there’s something here for everyone, we truly mean it. These are our picks for the books we think you should read this spring and summer."
                    },
                    new Post
                    {
                        Id = Guid.NewGuid(),
                        AuthorName = "MEGHAN O'GIEBLYN",
                        Header = "If Someone Is Typing, Then Stops … Can I Ask Why?",
                        PostedDate = new DateTime(2022, 04, 04),
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Content = "I'M KIND OF an anxious, obsessive texter. I never quite know what to say, but the worst is when I see someone typing—in iMessage, in Slack, whatever—and then they stop typing. And ultimately send nothing! What were they going to say? Am I allowed to ask? Surely I'm allowed to ask. Dear Nervous,You're certainly not alone in dreading this quirk of digital communication. The ellipsis, one of the most common indicators that someone is typing, is meant to create a sense of anticipation, recalling the pauses in fictional dialog or the ominous cliffhanger (to be continued …) that begs us to follow the dots, like a breadcrumb trail, to the narrative's conclusion.To watch the symbol disappear without the expected message is to experience the sinking disappointment we associate with paywalled articles and unresolved television seasons—stories without ends—and the absence of resolution can breed paranoia.Perhaps your conversational partner got abruptly distracted in the middle of her text.Perhaps she is obsessively rereading what she just wrote, weighing whether or not to press Send.Perhaps she was about to tell you, finally, what she really thinks of you, but at the last moment reconsidered.The ellipsis is also used in print to signal an omission, and it's this latter usage that comes to mind when the typing stops and no message arrives, leaving you with nothing more than the knowledge that the words signified by those three dots were deemed unworthy of your attention—or worse, you were deemed unworthy of them."
                    }
                   );
            base.OnModelCreating(builder);
        }
    }
}
