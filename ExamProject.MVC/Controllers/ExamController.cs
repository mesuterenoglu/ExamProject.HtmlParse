using ExamProject.Application.DTOs;
using ExamProject.Application.ServiceInterfaces;
using ExamProject.MVC.Models.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.MVC.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _questionOptionService;
        private readonly IPostService _postService;

        public ExamController(IExamService examService,IQuestionService questionService,IQuestionOptionService questionOptionService,IPostService postService)
        {
            _examService = examService;
            _questionService = questionService;
            _questionOptionService = questionOptionService;
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateExam()
        {
            var posts = await _postService.GetAllActiveAsync();
            ViewBag.Posts = posts;
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateExam(CreateExamVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ExamDto newExam = new ExamDto();
                    newExam.Id = Guid.NewGuid();
                    newExam.PostId = model.PostId;

                    QuestionDto question1 = new QuestionDto();
                    question1.Id = Guid.NewGuid();
                    question1.QuestionHeader = model.Question1;
                    question1.ExamId = newExam.Id;
                    question1.Options = new List<QuestionOptionDto> {
                        new QuestionOptionDto
                        {
                             Option = model.Question1Option1,
                             Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question1Option2,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question1Option3,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question1Option4,
                            Id = Guid.NewGuid()
                        }
                    };
                    switch (model.Question1CorrectOption)
                    {
                        case 'A':
                            question1.Options[0].IsCorrect = true;
                            break;
                        case 'B':
                            question1.Options[1].IsCorrect = true;
                            break;
                        case 'C':
                            question1.Options[2].IsCorrect = true;
                            break;
                        case 'D':
                            question1.Options[3].IsCorrect = true;
                            break;
                    }

                    QuestionDto question2 = new QuestionDto();
                    question2.Id = Guid.NewGuid();
                    question2.QuestionHeader = model.Question2;
                    question2.ExamId = newExam.Id;
                    question2.Options= new List<QuestionOptionDto> {
                        new QuestionOptionDto
                        {
                             Option = model.Question2Option1,
                             Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question2Option2,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question2Option3,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question2Option4,
                            Id = Guid.NewGuid()
                        }
                    };
                    switch (model.Question2CorrectOption)
                    {
                        case 'A':
                            question2.Options[0].IsCorrect = true;
                            break;
                        case 'B':
                            question2.Options[1].IsCorrect = true;
                            break;
                        case 'C':
                            question2.Options[2].IsCorrect = true;
                            break;
                        case 'D':
                            question2.Options[3].IsCorrect = true;
                            break;
                    }

                    QuestionDto question3 = new QuestionDto();
                    question3.Id = Guid.NewGuid();
                    question3.QuestionHeader = model.Question3;
                    question3.ExamId = newExam.Id;
                    question3.Options = new List<QuestionOptionDto> {
                        new QuestionOptionDto
                        {
                             Option = model.Question3Option1,
                             Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question3Option2,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question3Option3,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question3Option4,
                            Id = Guid.NewGuid()
                        }
                    };
                    switch (model.Question3CorrectOption)
                    {
                        case 'A':
                            question3.Options[0].IsCorrect = true;
                            break;
                        case 'B':
                            question3.Options[1].IsCorrect = true;
                            break;
                        case 'C':
                            question3.Options[2].IsCorrect = true;
                            break;
                        case 'D':
                            question3.Options[3].IsCorrect = true;
                            break;
                    }

                    QuestionDto question4 = new QuestionDto();
                    question4.Id = Guid.NewGuid();
                    question4.QuestionHeader = model.Question4;
                    question4.ExamId = newExam.Id;
                    question4.Options= new List<QuestionOptionDto> {
                        new QuestionOptionDto
                        {
                             Option = model.Question4Option1,
                             Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question4Option2,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question4Option3,
                            Id = Guid.NewGuid()
                        },
                        new QuestionOptionDto
                        {
                            Option = model.Question4Option4,
                            Id = Guid.NewGuid()
                        }
                    };
                    switch (model.Question4CorrectOption)
                    {
                        case 'A':
                            question4.Options[0].IsCorrect = true;
                            break;
                        case 'B':
                            question4.Options[1].IsCorrect = true;
                            break;
                        case 'C':
                            question4.Options[2].IsCorrect = true;
                            break;
                        case 'D':
                            question4.Options[3].IsCorrect = true;
                            break;
                    }

                    await _examService.AddAsync(newExam);
                    await _questionService.AddAsync(question1);
                    await _questionService.AddAsync(question2);
                    await _questionService.AddAsync(question3);
                    await _questionService.AddAsync(question4);

                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetExamListForAdmin()
        {
            try
            {
                var exams = await _examService.GetAllActiveAsync();
                return View(exams);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteExam(Guid id)
        {
            try
            {
                var result = await _examService.AnyAsync(id);
                if (result)
                {
                    await _examService.DeleteAsync(id);
                }
                else
                {
                    ViewBag.Error = "Böyle bir sınav bulunamadı!";
                }
                return RedirectToAction("GetExamList", "Exam");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<IActionResult> ExamList()
        {
            try
            {
                var exams = await _examService.GetAllActiveAsync();
                return View(exams);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> SolveExam(Guid id)
        {
            try
            {
                var exam = await _examService.GetbyIdAsync(id);
                if (exam != null)
                {
                    return View(exam);
                }
                return RedirectToAction("ExamList");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetOptionsbyExam([FromBody]Guid examId)
        {
            var options = await _questionOptionService.GetCorrectOptionsbyExamId(examId);
            if (options != null)
            {
                return Json(options);
            }
            throw new InvalidOperationException("Bu id ile sınav bulunamadı!");
        }
    }
}
