"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const StudentServices_1 = require("./services/StudentServices");
const service = new StudentServices_1.StudentService();
service.addStudent({ id: 1, name: "Dheeraj", marks: [85, 90, 88] });
service.addStudent({ id: 2, name: "Rahul", marks: [60, 70, 65] });
console.log(service.getStudentReport(1));
console.log(service.getStudentReport(2));
