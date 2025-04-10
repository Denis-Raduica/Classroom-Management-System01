# Classroom-Management-System

A platform that allows teachers to create and manage courses, share materials, assign homework, grade submissions, and communicate with students in an organized way. It also provides students with an easy way to view course materials, submit assignments, and receive feedback.

## Features:
- User Authentication
- Course Creation & Enrollment
- Assignment Submission & Grading
- Announcements & Messaging
- File Sharing (Course materials, assignments)
- API for handling assignments, grades, and notifications

## Functional Requirements:

1. **User Authentication**
   - Teachers and students can register and log in.
   - Role-based access control (teachers/students).

2. **Course Creation and Enrollment**
   - Teachers can create new courses and invite students.
   - Students can enroll in available courses.

3. **Assignments**
   - Teachers can post assignments with due dates.
   - Students can submit their assignments.
   - Teachers can grade assignments and provide feedback.

4. **Announcements and Messaging**
   - Teachers can send announcements to all students.
   - Students can message teachers or receive notifications.

5. **File Sharing**
   - Teachers can upload and share course materials (PDFs, slides, etc.).
   - Students can upload assignments.

6. **API**
   - RESTful API for handling assignment submissions, grading, and notifications.

## Architecture and Tech Stack:
- **Frontend**: Angular
- **Backend**: Node.js with Express
- **Database**: PostgreSQL (Azure Database for PostgreSQL)
- **File Storage**: Azure Blob Storage
- **Authentication**: JWT (JSON Web Tokens)
- **Deployment**: Azure Web Apps for Frontend and Backend

## Development Plan & Milestones:

### Phase 1: Setup & Authentication
- Setup GitHub repo and basic project structure.
- Implement user authentication (login, registration).
- Basic role-based access control for teachers and students.

### Phase 2: Course and Assignment Management
- Develop course creation and enrollment features.
- Implement assignment posting and submission functionality.

### Phase 3: File Sharing & Messaging
- Integrate file sharing (Azure Blob Storage).
- Implement messaging and notifications system.

### Phase 4: Testing & Deployment
- Write unit and integration tests.
- Deploy the application on Azure (Frontend and Backend).

## Directory Structure:

- `/frontend` - Angular front-end code
- `/backend` - Node.js backend code
  - `/controllers` - Business logic for handling requests
  - `/models` - Database schema
  - `/routes` - API routes
  - `/services` - Services like file handling, authentication
- `/database` - Database-related files (e.g., migrations, schema)
- `/storage` - Azure Blob Storage configuration
