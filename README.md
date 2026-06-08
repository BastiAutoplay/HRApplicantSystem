# HR Applicant Processing System
> Capstone Project — Windows Forms Desktop Application

A role-based HR recruitment management system built with **C# Windows Forms** and **MySQL**, supporting applicant self-service and full HR recruitment operations.

---

## Team Members

| Name | Assigned Screens |
|---|---|
| Sebastian V. Olivenza | Login, Register, Applicant Dashboard, My Profile, Database Setup |
| Kyle Zanie T. Paras | Job Vacancies, My Application, HR Applicant List, HR Applicant Review |
| Kurt Kevin A. Policarpio | HR Login, HR Dashboard, Interview Evaluation, Hiring Decision, Reports |
| Mark Christian Posadas | My Documents, Application Status, Screening, Interview Scheduling, Job Vacancy Management |

---

## System Overview

The system supports three types of users:

- **Applicant** — Register, log in, complete profile, apply for jobs, upload documents, track application status
- **HR Staff** — Review applications, screen candidates, schedule interviews, evaluate interviews
- **HR Manager / Admin** — Make final hiring decisions, manage job vacancies, generate reports

---

## Application Status Flow

```
Draft → Submitted → Under Review → Shortlisted → 
For Interview → For Final Review → Accepted / Rejected
```

---

## Database

- **Database:** MySQL 8.0
- **Tables:** 15 tables including Users, Roles, ApplicantAccounts, Applicants, JobVacancies, Applications, ApplicantDocuments, ScreeningResults, InterviewSchedules, InterviewEvaluations, HiringDecisions, ApplicationStatusHistory, AuditTrail, Departments, RequirementTypes

### Setup Instructions

1. Open MySQL Workbench
2. Open `database_setup.sql` from the project folder
3. Run the entire script
4. All 15 tables and sample data will be created automatically

---

## How to Run

### Requirements
- Windows 10 or Windows 11
- Visual Studio 2022 (with .NET desktop development workload)
- MySQL Server 8.0 or higher
- .NET Framework 4.7.2

### Steps

1. Clone the repository:
```
git clone https://github.com/BastiAutoplay/HRApplicantSystem.git
```

2. Open `HRApplicantSystem.slnx` in Visual Studio

3. Install the NuGet package:
   - Tools → NuGet Package Manager → Manage NuGet Packages for Solution
   - Search `MySql.Data` → Install

4. Set up the database:
   - Open MySQL Workbench
   - Run `database_setup.sql`

5. Update the database password in `Database/DBConnection.cs`:
```csharp
"Server=localhost;Database=hr_applicant_system;Uid=root;Pwd=Admin1234;"
```

6. Press **F5** to run the application

---

## Default Test Accounts

| Role | Email | Password |
|---|---|---|
| Admin | admin@hr.com | Admin1234 |
| HR Manager | manager@hr.com | Manager1234 |
| HR Staff | staff@hr.com | Staff1234 |
| Applicant | juan.dela.cruz@gmail.com | Password123 |

---

## Test Cases

| Test Case | Expected Result |
|---|---|
| Register with new email | Account created successfully |
| Register with existing email | System rejects duplicate |
| Submit application to open job | Status becomes Submitted |
| Apply twice to same job | System blocks duplicate |
| HR starts review | Status becomes Under Review, editing locked |
| Applicant tries to edit locked application | System prevents editing |
| HR Staff tries to accept applicant | Access Denied |
| HR Manager accepts applicant | Status becomes Accepted, history recorded |
| Schedule interview in the past | System rejects invalid date |
| View application status timeline | All changes shown in order |
| Upload missing document | Status updates to Submitted |
| Apply to closed job | System blocks application |

---

## AI Usage

AI assistance (Claude by Anthropic) was used to guide team members in learning C# Windows Forms, MySQL database design, and debugging. All code was personally typed, tested, and committed by each team member. See `AI_Usage_Explanation.txt` for full details.

---

## Deliverables

- [x] C# Source Code
- [x] MySQL Database Script with Sample Data
- [x] Flowchart
- [x] AI Usage Explanation
- [x] User Manual with Screenshots
- [x] GitHub Repository with Individual Member Commits

---

*Capstone Project | PUP San Pedro | BSIT 1-1*

