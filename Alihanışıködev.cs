using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Kaç öğrenci girmek istersiniz? ");
        int n = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Öğrencinin adını girin ({i + 1}/{n}): ");
            string name = Console.ReadLine();

            Console.Write($"Öğrencinin notunu girin (0-100): ");
            int grade;
            while (!int.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
            {
                Console.Write("Lütfen geçerli bir not girin (0-100): ");
            }

            students.Add(new Student(name, grade));
        }

        // Durum belirleme ve ortalama hesaplama
        int totalGrades = 0;
        int passedCount = 0;
        int failedCount = 0;
        Student highest = students[0];
        Student lowest = students[0];

        foreach (var student in students)
        {
            totalGrades += student.Grade;

            if (student.Grade >= 50)
            {
                student.Status = "Geçti";
                passedCount++;
            }
            else
            {
                student.Status = "Kaldı";
                failedCount++;
            }

            if (student.Grade > highest.Grade)
                highest = student;

            if (student.Grade < lowest.Grade)
                lowest = student;
        }

        double average = (double)totalGrades / n;

        // Sonuçları yazdırma
        Console.WriteLine("\nSınıfın Not Ortalaması: " + average);
        Console.WriteLine("En Yüksek Not: " + highest.Name + " - " + highest.Grade);
        Console.WriteLine("En Düşük Not: " + lowest.Name + " - " + lowest.Grade);

        Console.WriteLine("\nBaşarılı Öğrenciler:");
        foreach (var student in students)
        {
            if (student.Status == "Geçti")
                Console.WriteLine(student.Name + " - " + student.Grade);
        }

        Console.WriteLine("\nBaşarısız Öğrenciler:");
        foreach (var student in students)
        {
            if (student.Status == "Kaldı")
                Console.WriteLine(student.Name + " - " + student.Grade);
        }

        Console.WriteLine("\nEn Başarılı Öğrenci: " + highest.Name + " - " + highest.Grade);
        Console.WriteLine("En Zayıf Öğrenci: " + lowest.Name + " - " + lowest.Grade);
    }
}

class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Status { get; set; }

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
        Status = "Geçti"; // Varsayılan olarak geçiyor
    }
}