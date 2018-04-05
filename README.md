# Student Manager - For University Tutor to manage student's attendances

## Student Manager

## Edinburgh University teacher requires an app to manage courses, classrooms and students.

### MVP user should be able to:
- Create courses, lessons, students and study groups
- Course:
	- collection of lessons
	- multiple study groups
	- multiple lessons

- Study group:
	- can be associated with one course only
	- have a collection of lessons (from course)
	- have a collections of students

- Lesson:
	- can have one course associated with
	- can have collection of students (from study group)

- Student:
	- can enroll to multiple study groups

- Attendancy:
	- can have one course, one lesson and a collection of students


- The app should flag up absences as follows:
  - Flag first absence if lesson is mandatory
  - Flag on the third absence whether mandatory or optional

- The app should be able to create different size of smaller random groups within each class.

- The teacher needs to be able to define the number of students required in each group (eg: 2 students, 3-5 students).

- The app should be able to calculate:
  - % of absences by reasons (per course)
  - % of student absences by gender (per course)
  - % of absences per course by class

## Tech stack

- C# 
- Entity Framework 6 Code First using MVC 5