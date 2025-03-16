using Microsoft.AspNetCore.Mvc;
using Cumulative1.Model;

namespace Cumulative1.Controllers
{
    // TeacherPageController inherits from Controller
    public class TeacherPageController : Controller
    {
        // Dependency injection of TeacherAPIController
        private readonly TeacherAPIController _api;

        // Constructor for TeacherPageController
        public TeacherPageController(TeacherAPIController api)
        {
            _api = api; 
        }

        /// <summary>
        /// Displays a list of teachers on a dynamic page.
        /// </summary>
        /// <returns>A view containing all teachers.</returns>
        public IActionResult List()
        {
            // Fetch the list of teachers from the API
            List<Teacher> Teachers = _api.ListTeachers();

            // Specify the exact view path
            return View("~/Views/Teacher/List.cshtml", Teachers);
        }


        /// <summary>
        /// Displays details of a specific teacher by their ID.
        /// </summary>
        /// <param name="id">The ID of the teacher.</param>
        /// <returns>A view containing the teacher's details.</returns>
        public IActionResult Show(int id)
        {
            // Fetch the teacher by their ID from the API
            Teacher SelectedTeacher = _api.FindTeacher(id);

            // Specify the exact view path
            return View("~/Views/Teacher/Show.cshtml", SelectedTeacher);
        }

    }
}
