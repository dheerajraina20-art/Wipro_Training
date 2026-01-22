using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace TrainingManagementSystem
{
    // Simple class for Course
    class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public Course(string code, string name)
        {
            CourseCode = code;
            CourseName = name;
        }

        public void Display()
        {
            Console.WriteLine("Course Code: " + CourseCode + ", Course Name: " + CourseName);
        }
    }

    // Enrollment request class
    class EnrollmentRequest
    {
        public int LearnerId { get; set; }
        public string CourseCode { get; set; }

        public EnrollmentRequest(int learnerId, string courseCode)
        {
            LearnerId = learnerId;
            CourseCode = courseCode;
        }
    }

    // Admin action class (for undo)
    class AdminAction
    {
        public string ActionName { get; set; }

        public AdminAction(string actionName)
        {
            ActionName = actionName;
        }
    }

    // Training session class
    class TrainingSession
    {
        public string SessionName { get; set; }
        public DateTime StartTime { get; set; }

        public TrainingSession(string sessionName, DateTime startTime)
        {
            SessionName = sessionName;
            StartTime = startTime;
        }
    }

    class Program
    {
        static void Main()
        {
            // 1) Manage course catalog
            List<Course> courseCatalog = new List<Course>();

            courseCatalog.Add(new Course("C101", "C Sharp Basics"));
            courseCatalog.Add(new Course("C102", "OOP in C Sharp"));

            Console.WriteLine("1) Course Catalog using List:");
            foreach (var course in courseCatalog)
                course.Display();

            // 2) Fast course lookup by course code
            Dictionary<string, Course> courseLookup = new Dictionary<string, Course>();

            courseLookup["C101"] = new Course("C101", "C Sharp Basics");
            courseLookup["C102"] = new Course("C102", "OOP in C Sharp");

            Console.WriteLine("\n2) Fast Lookup using Dictionary:");
            if (courseLookup.ContainsKey("C101"))
                courseLookup["C101"].Display();

            // 3) Avoid duplicate learner enrollments
            HashSet<int> enrolledLearnersForC101 = new HashSet<int>();

            Console.WriteLine("\n3) Avoid Duplicate Enrollment using HashSet:");
            bool firstEnroll = enrolledLearnersForC101.Add(1001);
            bool secondEnroll = enrolledLearnersForC101.Add(1001);

            Console.WriteLine("First enrollment success: " + firstEnroll);
            Console.WriteLine("Second enrollment success: " + secondEnroll);

            // 4) Process enrollment requests in order received
            Queue<EnrollmentRequest> enrollmentQueue = new Queue<EnrollmentRequest>();

            enrollmentQueue.Enqueue(new EnrollmentRequest(1001, "C101"));
            enrollmentQueue.Enqueue(new EnrollmentRequest(1002, "C102"));
            enrollmentQueue.Enqueue(new EnrollmentRequest(1003, "C101"));

            Console.WriteLine("\n4) Process Enrollment Requests using Queue:");
            while (enrollmentQueue.Count > 0)
            {
                EnrollmentRequest req = enrollmentQueue.Dequeue();
                Console.WriteLine("Processing Enrollment -> Learner: " + req.LearnerId + ", Course: " + req.CourseCode);
            }

            // 5) Support undo for admin actions
            Stack<AdminAction> adminUndoStack = new Stack<AdminAction>();

            adminUndoStack.Push(new AdminAction("Added Course C103"));
            adminUndoStack.Push(new AdminAction("Updated Course C101"));
            adminUndoStack.Push(new AdminAction("Removed Course C102"));

            Console.WriteLine("\n5) Undo Last Admin Action using Stack:");
            AdminAction lastAction = adminUndoStack.Pop();
            Console.WriteLine("Undoing Action: " + lastAction.ActionName);

            // 6) Display sessions sorted by start time
            SortedList<DateTime, TrainingSession> sessionsSorted = new SortedList<DateTime, TrainingSession>();

            sessionsSorted.Add(new DateTime(2026, 1, 18, 9, 0, 0), new TrainingSession("OOP Session", new DateTime(2026, 1, 18, 9, 0, 0)));
            sessionsSorted.Add(new DateTime(2026, 1, 16, 10, 0, 0), new TrainingSession("C Sharp Intro Session", new DateTime(2026, 1, 16, 10, 0, 0)));
            sessionsSorted.Add(new DateTime(2026, 1, 20, 11, 0, 0), new TrainingSession("Exception Handling Session", new DateTime(2026, 1, 20, 11, 0, 0)));

            Console.WriteLine("\n6) Sessions Sorted by Start Time using SortedList:");
            foreach (var session in sessionsSorted.Values)
            {
                Console.WriteLine(session.SessionName + " starts at " + session.StartTime);
            }

            // 7) Handle concurrent enrollments
            ConcurrentDictionary<int, string> learnerEnrollments = new ConcurrentDictionary<int, string>();

            Console.WriteLine("\n7) Concurrent Enrollments using ConcurrentDictionary:");
            learnerEnrollments.TryAdd(1001, "C101");
            learnerEnrollments.TryAdd(1002, "C102");

            foreach (var item in learnerEnrollments)
            {
                Console.WriteLine("LearnerId: " + item.Key + " enrolled in: " + item.Value);
            }
        }
    }
}
