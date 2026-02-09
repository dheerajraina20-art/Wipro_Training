import type { Student } from "../models/Student";

export class StudentService {
  private students: Student[] = [];

  addStudent(student: Student): void {
    this.students.push(student);
  }

  calculateAverage(marks: number[]): number {
    return marks.reduce((a, b) => a + b, 0) / marks.length;
  }

  getGrade(avg: number): string {
    if (avg >= 90) return "A";
    if (avg >= 75) return "B";
    if (avg >= 50) return "C";
    return "Fail";
  }

  getStudentReport(id: number): string {
    const student = this.students.find(s => s.id === id);
    if (!student) return "Student not found";

    const avg = this.calculateAverage(student.marks);
    const grade = this.getGrade(avg);

    return `${student.name} - Avg: ${avg.toFixed(2)} Grade: ${grade}`;
  }
}