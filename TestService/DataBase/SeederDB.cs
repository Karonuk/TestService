using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestService.DataBase.Entites;

namespace TestService.DataBase
{
    public class SeederDB
    {
        private static void SeedUser(EFContext context)
        {
            if (context.Users.Count() > 0)
            {
                return;
            }
            context.Users.Add(new User
            {
                Email = "user1@gmail.com",
                Password = "Qwerty1-",
            });
            context.Users.Add(new User
            {
                Email = "user2@gmail.com",
                Password = "Qwerty1-",
            });
            context.SaveChanges();
        }
        private static void SeedTests(EFContext context)
        {
            if (context.Tests.Count() > 0)
            {
                return;
            }
            var userId = context.Users.FirstOrDefault(x => x.Email == "user1@gmail.com").Id;
            context.Tests.Add(new Test
            {
                Name="Math test",
                TestDescription="Special Math test for user 1",
                UserId=userId
            });
            context.Tests.Add(new Test
            {
                Name = "English test",
                TestDescription = "Special english test for user 1",
                UserId = userId
            });
            userId= context.Users.FirstOrDefault(x => x.Email == "user2@gmail.com").Id;
            context.Tests.Add(new Test
            {
                Name = "Actor test",
                TestDescription = "Special Math test for user 2",
                UserId = userId
            });
            context.SaveChanges();
        }
        private static void SeedQuestions(EFContext context)
        {
            if (context.Questions.Count() > 0)
            {
                return;
            }
            var testId = context.Tests.FirstOrDefault(x => x.Name == "Math test").Id;
            context.Questions.Add(new Question
            {
                QuestionText="2+2=",
                TestId=testId
            });
            context.Questions.Add(new Question
            {
                QuestionText="2^3=",
                TestId=testId
            });
            context.Questions.Add(new Question
            {
                QuestionText = "tan45=",
                TestId = testId
            });
            testId = context.Tests.FirstOrDefault(x => x.Name == "English test").Id;
            context.Questions.Add(new Question
            {
                QuestionText="Choose the different word",
                TestId=testId
            });
            context.Questions.Add(new Question
            {
                QuestionText="Choose the word: We've borrowed some money [word] my parrents",
                TestId=testId
            });
            context.Questions.Add(new Question
            {
                QuestionText = "Choose the correct word: My sister ... sea food",
                TestId = testId
            });            
            testId = context.Tests.FirstOrDefault(x => x.Name == "Actor test").Id;
            context.Questions.Add(new Question
            {
                QuestionText = "Actor played Doctor House in famous TV series",
                TestId = testId
            });
            context.Questions.Add(new Question
            {
                QuestionText = "Which of these films did not feature Benedict Cumberbatch",
                TestId=testId
            });
            context.Questions.Add(new Question
            {
                QuestionText="Which of this films has a Tom Holland im main role",
                TestId=testId,
            });
            context.SaveChanges();
        }
        private static void SeedAnswers(EFContext context)
        {
            if (context.Answers.Count() > 0)
            {
                return;
            }
            var questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "2+2=").Id;
            context.Answers.Add(new Answer
            {
                Text="3",
                IsCorrect=false,
                QuestionId=questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "1",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "4",
                IsCorrect = true,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "2^3=").Id;
            context.Answers.Add(new Answer
            {
                Text = "6",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "8",
                IsCorrect = true,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "9",
                IsCorrect = false,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "tan45=").Id;
            context.Answers.Add(new Answer
            {
                Text = "2",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "1",
                IsCorrect = true,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "0",
                IsCorrect = false,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "Choose the different word").Id;
            context.Answers.Add(new Answer
            {
                Text = "lamb",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "crab",
                IsCorrect = true,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "beef",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "pork",
                IsCorrect = false,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "Choose the word: We've borrowed some money [word] my parrents").Id;
            context.Answers.Add(new Answer
            {
                Text = "in",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "at",
                IsCorrect = false,
                QuestionId = questionId
            });            
            context.Answers.Add(new Answer
            {
                Text = "from",
                IsCorrect = true,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "on",
                IsCorrect = false,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "Choose the correct word: My sister ... sea food").Id;
            context.Answers.Add(new Answer
            {
                Text = "Doesn't like",
                IsCorrect = true,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Isn't like",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Don't like",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Aren't like",
                IsCorrect = false,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "Actor played Doctor House in famous TV series").Id;
            context.Answers.Add(new Answer
            {
                Text = "Hugh Laurie",
                IsCorrect = true,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Tom Hanks",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Steve Martin",
                IsCorrect = false,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "Which of these films did not feature Benedict Cumberbatch").Id;
            context.Answers.Add(new Answer
            {
                Text = "Avengers:Endgame",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Doctor Strange",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "The Avengers",
                IsCorrect = true,
                QuestionId = questionId
            });
            questionId = context.Questions.FirstOrDefault(x => x.QuestionText == "Which of this films has a Tom Holland im main role").Id;
            context.Answers.Add(new Answer
            {
                Text = "Uncharted",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Spider-Man: Homecoming",
                IsCorrect = false,
                QuestionId = questionId
            });
            context.Answers.Add(new Answer
            {
                Text = "Captain America: Civil War",
                IsCorrect = true,
                QuestionId = questionId
            });
            context.SaveChanges();
        }
        public static void SeedData(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EFContext>();

                SeedUser(context);
                SeedTests(context);
                SeedQuestions(context);
                SeedAnswers(context);
            }
        }
    }
}
