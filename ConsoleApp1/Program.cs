using ConsoleApp1;

List<Student> students = new List<Student>();



string option;
do
{
    Console.WriteLine("\tMenu:\n");
    Console.WriteLine("1. Telebe elave et");
    Console.WriteLine("2. Telebeye imtahan elave et");
    Console.WriteLine("3. Telebenin bir imtahan balına bax");
    Console.WriteLine("4. Telebenin bütün imtahanlarını goster");
    Console.WriteLine("5. Telebenin imtahan ortalamasını goster");
    Console.WriteLine("6. Telebeden imtahan sil");
    Console.WriteLine("0. Proqramı bitir");

    Console.WriteLine("Emeliyyati daxil et: ");
    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            string fullName;
            do
            {
                Console.Write("Telebe adını daxil edin: ");
                fullName = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(fullName));
            
            students.Add(new Student { No = students.Count + 1, FullName = fullName });
            Console.WriteLine("Telebe elave edildi.");
            break;

        case "2":
            ShowAllStudents(students);
            Console.Write("Telebe nomresini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int studentNo) && studentNo > 0 && studentNo <= students.Count)
            {
                Student student = students[studentNo - 1];
                Console.WriteLine("Imtahan adını secin:");
                ShowExamOptions();
                if (Enum.TryParse(Console.ReadLine(), out Exam exam) && Enum.IsDefined(typeof(Exam), exam))
                {
                    EnterPoint:
                    Console.Write("Imtahan neticesini daxil edin: ");
                    if (int.TryParse(Console.ReadLine(), out int point))
                    {
                        student.AddExam(exam, point);
                        Console.WriteLine("Imtahan elave edildi.");
                    }
                    else
                    {
                        Console.WriteLine("Neticeni duzgun daxil edin.");
                        goto EnterPoint;
                    }
                }
                else
                {
                    Console.WriteLine("Secdiyiniz imtahan movcud deyil.");
                }
            }
            else
            {
                Console.WriteLine("Telebe nomresi duzgun daxil edilmeyib.");
            }
            break;

        case "3":
            ShowAllStudents(students);
            Console.Write("Telebe nomresini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int studentNumber) && studentNumber > 0 && studentNumber <= students.Count)
            {
                Student student = students[studentNumber - 1];
                Console.WriteLine("Imtahan adını seçin:");
                ShowExamOptions();
                if (Enum.TryParse(Console.ReadLine(), out Exam exam) && Enum.IsDefined(typeof(Exam), exam))
                {
                    int result = student.GetExamResult(exam);
                    if (result != -1)
                    {
                        Console.WriteLine($"{exam} imtahanının neticesi: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Bu imtahan tapılmadı.");
                    }
                }
                else
                {
                    Console.WriteLine("Secdiyiniz imtahan movcud deyil.");
                }
            }
            else
            {
                Console.WriteLine("Telebe nomresi duzgun daxil edilmeyib.");
            }
            break;

        case "4":
            ShowAllStudents(students);
            Console.Write("Telebe nomresini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int studentNum) && studentNum > 0 && studentNum <= students.Count)
            {
                Student student = students[studentNum - 1];
                Console.WriteLine($"Telebenin bütün imtahanları ve neticeleri:");
                foreach (var exam in student.Exams)
                {
                    Console.WriteLine($"{exam.Key}: {exam.Value}");
                }
            }
            else
            {
                Console.WriteLine("Telebe nomresi duzgun daxil edilmeyib.");
            }
            break;

        case "5":
            ShowAllStudents(students);
            Console.Write("Telebe nomresini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int studentNumAvg) && studentNumAvg > 0 && studentNumAvg <= students.Count)
            {
                Student student = students[studentNumAvg - 1];
                double avg = student.GetExamAvg();
                Console.WriteLine($"Telebenin imtahan ortalamasi: {avg}");
            }
            else
            {
                Console.WriteLine("Telebe nomresi duzgun daxil edilmeyib.");
            }
            break;

        case "6":
            ShowAllStudents(students);
            Console.Write("Telebe nomresini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int studentNoRemove) && studentNoRemove > 0 && studentNoRemove <= students.Count)
            {
                Student student = students[studentNoRemove - 1];
                Console.WriteLine("Imtahan adını secin:");
                ShowExamOptions();
                if (Enum.TryParse(Console.ReadLine(), out Exam examRemove) && Enum.IsDefined(typeof(Exam), examRemove))
                {
                    student.RemoveExam(examRemove);
                    Console.WriteLine($"{examRemove} imtahanı silindi.");
                }
                else
                {
                    Console.WriteLine("Secdiyiniz imtahan movcud deyil.");
                }
            }
            else
            {
                Console.WriteLine("Telebe nomresi duzgun daxil edilmeyib.");
            }
            break;
        case "0":
            Console.WriteLine("Proqram Bitdi!");
            break;
        default:
            Console.WriteLine("Yanlis secim!");
            break;
    }


} while (option != "0");


static void ShowExamOptions()
{
    foreach (Exam exam in Enum.GetValues(typeof(Exam)))
    {
        Console.WriteLine($"{(int)exam}. {exam}");
    }
}

static void ShowAllStudents(List<Student> students)
{
    Console.WriteLine("\tTelebeler: \n");
    foreach (var student in students)
    {
        Console.WriteLine(student.No +" - "+student.FullName);
    }
}