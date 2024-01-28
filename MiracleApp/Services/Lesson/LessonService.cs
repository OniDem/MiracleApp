using Core.Const;
using Core.Entity;
using DTO.Lesson;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MiracleApp.Services.Lesson
{
    static class LessonService
    {
        public static async Task<bool> CreateLesson(CreateLessonRequest request)
        {
            string serverURI = "http://45.153.69.204:5000/Lesson/Create";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            JsonContent content = JsonContent.Create(request);
            HttpResponseMessage response = await httpClient.PostAsync(serverURI, content);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<LessonEntity>> ShowAll()
        {
            string serverURI = "http://45.153.69.204:5000/Lesson/ShowAll";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            Dictionary<string, string> Params = new()
            {

            };
            FormUrlEncodedContent content = new(Params);
            HttpResponseMessage response = await httpClient.PostAsync(serverURI, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LessonEntity>>(result);
            }
            return null;
        }

        public static async Task<List<LessonEntity>> ShowByWeek(ShowByWeekRequest request)
        {
            string serverURI = "http://45.153.69.204:5000/Lesson/ShowByWeek";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("token"));
            JsonContent content = JsonContent.Create(request);
            HttpResponseMessage response = await httpClient.PostAsync(serverURI, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LessonEntity>>(result);
            }
            return null;
        }

        public static async Task<List<List<ShowLessonEntity>>> ShowAllLessons(int week)
        {
            List<List<ShowLessonEntity>> showLessons = new()
            {
                new() {},
                new() {},
                new() {},
                new() {},
                new() {},
                new() {},
                new() {},
            };
            var lessons = await ShowByWeek(new() { Week = week });
            foreach (var lesson in lessons)
            {
                switch (lesson.DayOfWeek)
                {
                    case LessonDoWEnum.Mo:
                        showLessons[0].Add(new()
                        {
                            Where = lesson.Where,
                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                            TimeStart = lesson.TimeStart,
                            TimeEnd = lesson.TimeEnd,
                        });
                        break;
                    case LessonDoWEnum.Tu:
                        showLessons[1].Add(new()
                        {
                            Where = lesson.Where,
                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                            TimeStart = lesson.TimeStart,
                            TimeEnd = lesson.TimeEnd,
                        });
                        break;
                    case LessonDoWEnum.We:
                        showLessons[2].Add(new()
                        {
                            Where = lesson.Where,
                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                            TimeStart = lesson.TimeStart,
                            TimeEnd = lesson.TimeEnd,
                        });
                        break;
                    case LessonDoWEnum.Th:
                        showLessons[3].Add(new()
                        {
                            Where = lesson.Where,
                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                            TimeStart = lesson.TimeStart,
                            TimeEnd = lesson.TimeEnd,
                        });
                        break;
                    case LessonDoWEnum.Fr:
                        showLessons[4].Add(new()
                        {
                            Where = lesson.Where,
                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                            TimeStart = lesson.TimeStart,
                            TimeEnd = lesson.TimeEnd,
                        });
                        break;
                    case LessonDoWEnum.Sa:
                        showLessons[5].Add(new()
                        {
                            Where = lesson.Where,
                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                            TimeStart = lesson.TimeStart,
                            TimeEnd = lesson.TimeEnd,
                        });
                        break;
                    case LessonDoWEnum.Su:
                        showLessons[6].Add(new()
                        {
                            Where = lesson.Where,
                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                            TimeStart = lesson.TimeStart,
                            TimeEnd = lesson.TimeEnd,
                        });
                        break;
                    default:
                        break;
                }

            }
            return showLessons;
        }

        public static async Task<List<List<ShowLessonEntity>>> ShowAllLessons(int week, LessonShowPropertiesEntity properties)
        {
            List<List<ShowLessonEntity>> showLessons = new()
            {
                new() {},
                new() {},
                new() {},
                new() {},
                new() {},
                new() {},
                new() {},
            };
            var lessons = await ShowByWeek(new() { Week = week });
            foreach (var lesson in lessons)
            {
                if ((lesson.CourseNumber == properties.Cource) && (lesson.Department == properties.Department) && (lesson.Branch == properties.Branch))
                {
                    switch (lesson.DayOfWeek)
                    {
                        case LessonDoWEnum.Mo:
                            showLessons[0].Add(new()
                            {
                                Where = lesson.Where,
                                Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                TimeStart = lesson.TimeStart,
                                TimeEnd = lesson.TimeEnd,
                            });
                            break;
                        case LessonDoWEnum.Tu:
                            showLessons[1].Add(new()
                            {
                                Where = lesson.Where,
                                Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                TimeStart = lesson.TimeStart,
                                TimeEnd = lesson.TimeEnd,
                            });
                            break;
                        case LessonDoWEnum.We:
                            showLessons[2].Add(new()
                            {
                                Where = lesson.Where,
                                Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                TimeStart = lesson.TimeStart,
                                TimeEnd = lesson.TimeEnd,
                            });
                            break;
                        case LessonDoWEnum.Th:
                            showLessons[3].Add(new()
                            {
                                Where = lesson.Where,
                                Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                TimeStart = lesson.TimeStart,
                                TimeEnd = lesson.TimeEnd,
                            });
                            break;
                        case LessonDoWEnum.Fr:
                            showLessons[4].Add(new()
                            {
                                Where = lesson.Where,
                                Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                TimeStart = lesson.TimeStart,
                                TimeEnd = lesson.TimeEnd,
                            });
                            break;
                        case LessonDoWEnum.Sa:
                            showLessons[5].Add(new()
                            {
                                Where = lesson.Where,
                                Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                TimeStart = lesson.TimeStart,
                                TimeEnd = lesson.TimeEnd,
                            });
                            break;
                        case LessonDoWEnum.Su:
                            showLessons[6].Add(new()
                            {
                                Where = lesson.Where,
                                Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                TimeStart = lesson.TimeStart,
                                TimeEnd = lesson.TimeEnd,
                            });
                            break;
                        default:
                            break;
                    }
                }
            }
            return showLessons;
        }

    }
}
