using Xunit;
using Moq;
using Api.Controllers;
using Api.Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class PatientsControllerTest
{
    [Fact]
    public void Post_ShouldAddPatient()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Patient>>();
        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(m => m.Patients).Returns(mockSet.Object);

        var patient = new Patient(
            1,
            "Test",
            "Patient",
            'M',
            DateTime.Now.AddYears(-30),
            170,
            70,
            "12345678901"
        );
        var controller = new PatientsController(mockContext.Object);

        // Act
        controller.Post(patient);

        // Assert
        mockSet.Verify(m => m.Add(It.IsAny<Patient>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [Fact]
    public void Get_ShouldReturnPatients()
    {
        // Arrange
        var data = new List<Patient>
        {
            new Patient(1, "Test1", "Patient1", 'M', DateTime.Now.AddYears(-15), 170, 70, "12345678901"),
            new Patient(2, "Test2", "Patient2", 'F', DateTime.Now.AddYears(-30), 170, 70, "12345678902"),
            new Patient(3, "Test3", "Patient3", 'M', DateTime.Now.AddYears(-30), 170, 70, "12345678903")
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Patient>>();
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(c => c.Patients).Returns(mockSet.Object);

        var controller = new PatientsController(mockContext.Object);

        // Act
        var patients = controller.Get();

        // Assert
        if (patients.Value != null)
        {
            Assert.Equal(3, patients.Value.Count());
        }
        else
        {
            Assert.True(false, "Patients value is null");
        }
    }

    [Fact]
    public void Get_ShouldReturnPatient()
    {
        // Arrange
        var data = new List<Patient>
        {
            new Patient(1, "Test1", "Patient1", 'M', DateTime.Now.AddYears(-30), 170, 70, "12345678901"),
            new Patient(2, "Test2", "Patient2", 'M', DateTime.Now.AddYears(-25), 170, 70, "12345678902"),
            new Patient(3, "Test3", "Patient3", 'F', DateTime.Now.AddYears(-35), 170, 70, "12345678903")
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Patient>>();
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(c => c.Patients).Returns(mockSet.Object);

        var controller = new PatientsController(mockContext.Object);

        // Act
        var patient = controller.Get(1);

        // Assert
        if (patient.Value != null)
        {
            Assert.Equal("Test1", patient.Value.Nome);
        }
        else
        {
            Assert.True(false, "Patients value is null");
        }
    }

    [Fact]
    public void Put_ShouldUpdatePatient()
    {
        // Arrange
        var data = new List<Patient>
        {
            new Patient(1, "Test1", "Patient1", 'M', DateTime.Now.AddYears(-35), 170, 70, "12345678901"),
            new Patient(2, "Test2", "Patient2", 'M', DateTime.Now.AddYears(-30), 170, 70, "12345678902"),
            new Patient(3, "Test3", "Patient3", 'F', DateTime.Now.AddYears(-20), 170, 70, "12345678903")
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Patient>>();
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(c => c.Patients).Returns(mockSet.Object);

        var controller = new PatientsController(mockContext.Object);

        // Act
        controller.Put(1, new Patient(1, "Test1", "Patient1", 'M', DateTime.Now.AddYears(-30), 170, 70, "12345678901"));

        // Assert
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [Fact]
    public void Delete_ShouldRemovePatient()
    {
        // Arrange
        var data = new List<Patient>
        {
            new Patient(1, "Test1", "Patient1", 'M', DateTime.Now.AddYears(-30), 170, 70, "12345678901"),
            new Patient(2, "Test2", "Patient2", 'M', DateTime.Now.AddYears(-25), 170, 70, "12345678902"),
            new Patient(3, "Test3", "Patient3", 'F', DateTime.Now.AddYears(-35), 170, 70, "12345678903")
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Patient>>();
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationDbContext>();
        mockContext.Setup(c => c.Patients).Returns(mockSet.Object);

        var controller = new PatientsController(mockContext.Object);

        // Act
        controller.Delete(1);

        // Assert
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [Fact]
    public void Test_Can_Create_Many_Patients()
    {
        // Arrange
        var patients = new List<Patient>();

        // Act
        for (int i = 0; i < 100000; i++)
        {
            var patient = new Patient(
                i + 1,
                "Test" + i,
                "Patient" + i,
                'M',
                DateTime.Now.AddYears(-30),
                170,
                70,
                "12345678901".Substring(0, i.ToString().Length) + i.ToString()
            );
            patients.Add(patient);
        }

        // Assert
        Assert.Equal(100000, patients.Count);
    }
}
