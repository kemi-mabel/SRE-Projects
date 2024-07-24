using System.Collections.Generic;
using System.Linq;
using api.Controllers;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace StudentAPI.Tests
{
    public class StudentsControllerTest
    {
        private readonly StudentsController _controller;
        private readonly ApplicationDBContext _context;

        public StudentsControllerTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDBContext(options);

            _controller = new StudentsController(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // Clear existing data
            _context.StudentRegister.RemoveRange(_context.StudentRegister);
            _context.SaveChanges();

            // Add new seed data with unique integer IDs
            _context.StudentRegister.AddRange(
                new Student { Id = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john@example.com", Programme = "Science", Level = "one" },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "jane@example.com", Programme = "Arts", Level = "two" }
            );
            _context.SaveChanges();
        }

        [Fact]
        public void GetAllStudents_ReturnsAllStudents()
        {
            // Act
            var result = _controller.GetAllStudents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var students = Assert.IsType<List<Student>>(okResult.Value);
            Assert.Equal(2, students.Count);
        }

        [Fact]
        public void GetStudentById_ReturnsStudent()
        {
            // Act
            var result = _controller.GetStudentById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var student = Assert.IsType<Student>(okResult.Value);
            Assert.Equal(1, student.Id);
        }

        [Fact]
        public void GetStudentById_ReturnsNotFound()
        {
            // Act
            var result = _controller.GetStudentById(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void AddStudent_ReturnsOkResult()
        {
            // Arrange
            var newStudent = new AddStudentDto
            {
                FirstName = "Alice",
                LastName = "Wonderland",
                EmailAddress = "alice@example.com",
                Programme = "Mathematics",
                Level = "three"
            };

            // Act
            var result = _controller.AddStudent(newStudent);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var student = Assert.IsType<Student>(okResult.Value);
            Assert.Equal("Alice", student.FirstName);
        }

        [Fact]
        public void UpdateStudent_ReturnsOkResult()
        {
            // Arrange
            var updatedStudent = new EditStudentDto
            {
                FirstName = "Updated",
                LastName = "Name",
                EmailAddress = "updated@example.com",
                Programme = "UpdatedProgramme",
                Level = "four"
            };

            // Act
            var result = _controller.UpdateStudent(1, updatedStudent);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var student = Assert.IsType<Student>(okResult.Value);
            Assert.Equal("Updated", student.FirstName);
        }

        [Fact]
        public void UpdateStudent_ReturnsNotFound()
        {
            // Arrange
            var updatedStudent = new EditStudentDto
            {
                FirstName = "NonExistent",
                LastName = "Student",
                EmailAddress = "nonexistent@example.com",
                Programme = "None",
                Level = "zero"
            };

            // Act
            var result = _controller.UpdateStudent(99, updatedStudent);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteStudent_ReturnsOkResult()
        {
            // Act
            var result = _controller.DeleteStudent(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteStudent_ReturnsNotFound()
        {
            // Act
            var result = _controller.DeleteStudent(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
