import { StudentService } from "./services/StudentServices";

const service = new StudentService();

service.addStudent({ id: 1, name: "Dheeraj", marks: [85, 90, 88] });
service.addStudent({ id: 2, name: "Rahul", marks: [60, 70, 65] });

console.log(service.getStudentReport(1));
console.log(service.getStudentReport(2));

/*
PROJECT SETUP STEPS (TERMINAL COMMANDS)

1. Created project folder
   mkdir ts-student-project
   cd ts-student-project

2. Initialized Node project
   npm init -y

3. Installed TypeScript locally
   npm install typescript --save-dev

4. Created TypeScript config file
   npx tsc --init

5. Edited tsconfig.json to:
   - Set rootDir as ./src
   - Set outDir as ./dist
   - Use commonjs module
   - Enable strict mode

6. Created project folders
   mkdir src
   mkdir src/models
   mkdir src/services

7. Compiled TypeScript to JavaScript
   npx tsc

8. Ran the compiled program using Node
   node dist/app.js
*/

/*
PROJECT IMPLEMENTATION STEPS

1. Created an interface (Student.ts)
   - Defines structure of a student
   - Includes id, name, and marks array

2. Created a service class (StudentService.ts)
   - Stores students in an array
   - addStudent() → adds a new student
   - calculateAverage() → calculates average marks
   - getGrade() → assigns grade based on average
   - getStudentReport() → returns formatted result

3. Created main file (app.ts)
   - Created an object of StudentService
   - Added student data
   - Called getStudentReport() to display results

4. TypeScript ensured:
   - Proper data types
   - Compile-time error checking
   - Safe and structured code

5. Code was compiled using TypeScript compiler (tsc)
6. Output JavaScript file was executed using Node.js
*/
