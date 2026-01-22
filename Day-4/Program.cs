using System;
namespace miniproj
{
  class Student
  {
    string name;
    int rollno;
    int totalmarks;
    
    public void displayscores()
    {
      Console.WriteLine(name);
      Console.WriteLine(rollno);
      Console.WriteLine(totalmarks);
    }
    
    public static void Main(string[] args)
    {
      Student s1 = new Student();
      s1.name = "Dheeraj";
      s1.rollno = 212;
      s1.totalmarks = 100;
      
      Student s2 = new Student();
      s2.name = "Sruthi";
      s2.rollno = 211;
      s2.totalmarks=100;
      
      Console.WriteLine("Details");
      Console.WriteLine(s1.name+" "+s1.rollno+" "+s1.totalmarks);
      Console.WriteLine(s2.name+" "+s2.rollno+" "+s2.totalmarks);
      
    }
  }
}