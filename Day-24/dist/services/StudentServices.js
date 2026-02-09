"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.StudentService = void 0;
class StudentService {
    constructor() {
        this.students = [];
    }
    addStudent(student) {
        this.students.push(student);
    }
    calculateAverage(marks) {
        return marks.reduce((a, b) => a + b, 0) / marks.length;
    }
    getGrade(avg) {
        if (avg >= 90)
            return "A";
        if (avg >= 75)
            return "B";
        if (avg >= 50)
            return "C";
        return "Fail";
    }
    getStudentReport(id) {
        const student = this.students.find(s => s.id === id);
        if (!student)
            return "Student not found";
        const avg = this.calculateAverage(student.marks);
        const grade = this.getGrade(avg);
        return `${student.name} - Avg: ${avg.toFixed(2)} Grade: ${grade}`;
    }
}
exports.StudentService = StudentService;
