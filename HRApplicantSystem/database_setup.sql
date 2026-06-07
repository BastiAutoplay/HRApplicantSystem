CREATE DATABASE IF NOT EXISTS hr_applicant_system;
USE hr_applicant_system;

-- TABLE 1: Roles
CREATE TABLE Roles (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL,
    Description VARCHAR(255)
);

-- TABLE 2: Users
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    RoleID INT NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    IsActive TINYINT(1) DEFAULT 1,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- TABLE 3: ApplicantAccounts
CREATE TABLE ApplicantAccounts (
    ApplicantAccountID INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    IsActive TINYINT(1) DEFAULT 1,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- TABLE 4: Applicants
CREATE TABLE Applicants (
    ApplicantID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicantAccountID INT NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    MiddleName VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(255),
    DateOfBirth DATE,
    Gender VARCHAR(20),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ApplicantAccountID) 
        REFERENCES ApplicantAccounts(ApplicantAccountID)
);

-- TABLE 5: Departments
CREATE TABLE Departments (
    DepartmentID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL,
    Description VARCHAR(255)
);

-- TABLE 6: JobVacancies
CREATE TABLE JobVacancies (
    JobID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentID INT,
    JobTitle VARCHAR(100) NOT NULL,
    Description TEXT,
    Qualifications TEXT,
    EmploymentType VARCHAR(50),
    Status VARCHAR(20) DEFAULT 'Open',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- TABLE 7: Applications
CREATE TABLE Applications (
    ApplicationID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicantID INT NOT NULL,
    JobID INT NOT NULL,
    Status VARCHAR(50) DEFAULT 'Draft',
    AppliedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    LastUpdated DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ApplicantID) REFERENCES Applicants(ApplicantID),
    FOREIGN KEY (JobID) REFERENCES JobVacancies(JobID)
);

-- TABLE 8: RequirementTypes
CREATE TABLE RequirementTypes (
    RequirementTypeID INT AUTO_INCREMENT PRIMARY KEY,
    RequirementName VARCHAR(100) NOT NULL,
    Description VARCHAR(255)
);

-- TABLE 9: ApplicantDocuments
CREATE TABLE ApplicantDocuments (
    DocumentID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicationID INT NOT NULL,
    RequirementTypeID INT NOT NULL,
    FileName VARCHAR(255),
    FilePath VARCHAR(500),
    Status VARCHAR(20) DEFAULT 'Missing',
    UploadedAt DATETIME,
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (RequirementTypeID) 
        REFERENCES RequirementTypes(RequirementTypeID)
);

-- TABLE 10: ScreeningResults
CREATE TABLE ScreeningResults (
    ScreeningID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicationID INT NOT NULL,
    ScreenedBy INT NOT NULL,
    Result VARCHAR(20),
    Remarks TEXT,
    ScreenedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (ScreenedBy) REFERENCES Users(UserID)
);

-- TABLE 11: InterviewSchedules
CREATE TABLE InterviewSchedules (
    InterviewID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicationID INT NOT NULL,
    InterviewerID INT NOT NULL,
    ScheduledDate DATETIME NOT NULL,
    Mode VARCHAR(50),
    Location VARCHAR(255),
    Status VARCHAR(20) DEFAULT 'Scheduled',
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (InterviewerID) REFERENCES Users(UserID)
);

-- TABLE 12: InterviewEvaluations
CREATE TABLE InterviewEvaluations (
    EvaluationID INT AUTO_INCREMENT PRIMARY KEY,
    InterviewID INT NOT NULL,
    Score DECIMAL(5,2),
    Remarks TEXT,
    Result VARCHAR(20),
    EvaluatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (InterviewID) 
        REFERENCES InterviewSchedules(InterviewID)
);

-- TABLE 13: HiringDecisions
CREATE TABLE HiringDecisions (
    DecisionID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicationID INT NOT NULL,
    DecidedBy INT NOT NULL,
    Decision VARCHAR(20) NOT NULL,
    Remarks TEXT,
    DecidedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (DecidedBy) REFERENCES Users(UserID)
);

-- TABLE 14: ApplicationStatusHistory
CREATE TABLE ApplicationStatusHistory (
    HistoryID INT AUTO_INCREMENT PRIMARY KEY,
    ApplicationID INT NOT NULL,
    Status VARCHAR(50) NOT NULL,
    Remarks TEXT,
    ChangedBy VARCHAR(100),
    ChangedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID)
);

-- TABLE 15: AuditTrail
CREATE TABLE AuditTrail (
    AuditID INT AUTO_INCREMENT PRIMARY KEY,
    UserType VARCHAR(20),
    UserID INT,
    Action VARCHAR(255),
    AffectedTable VARCHAR(100),
    AffectedID INT,
    ActionAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- SAMPLE DATA
INSERT INTO Roles (RoleName, Description) VALUES
('Admin', 'Full system access'),
('HR Manager', 'Can make final hiring decisions'),
('HR Staff', 'Can review and process applicants');

INSERT INTO Users (RoleID, FullName, Email, PasswordHash) VALUES
(1, 'System Admin', 'admin@hr.com', 'Admin1234'),
(2, 'HR Manager Juan', 'manager@hr.com', 'Manager1234'),
(3, 'HR Staff Maria', 'staff@hr.com', 'Staff1234');

INSERT INTO Departments (DepartmentName) VALUES
('Information Technology'),
('Human Resources'),
('Finance'),
('Operations');

INSERT INTO RequirementTypes (RequirementName) VALUES
('Resume'),
('Government ID'),
('Transcript of Records'),
('Certificate of Employment'),
('NBI Clearance');


USE hr_applicant_system;

-- Sample Applicant Accounts
INSERT INTO ApplicantAccounts (Email, PasswordHash) VALUES
('juan.dela.cruz@gmail.com', 'Password123'),
('maria.santos@gmail.com', 'Password123'),
('pedro.reyes@gmail.com', 'Password123');

-- Sample Applicant Profiles
INSERT INTO Applicants (ApplicantAccountID, FirstName, LastName, Phone, Address, Gender) VALUES
(1, 'Juan', 'Dela Cruz', '09171234567', 'Quezon City, Metro Manila', 'Male'),
(2, 'Maria', 'Santos', '09281234567', 'Makati City, Metro Manila', 'Female'),
(3, 'Pedro', 'Reyes', '09391234567', 'Pasig City, Metro Manila', 'Male');

-- Sample Applications
INSERT INTO Applications (ApplicantID, JobID, Status) VALUES
(1, 1, 'Accepted'),
(2, 2, 'For Interview'),
(3, 3, 'Submitted');

-- Sample Status History for Juan
INSERT INTO ApplicationStatusHistory (ApplicationID, Status, ChangedBy, Remarks) VALUES
(1, 'Draft', 'Applicant', 'Application created'),
(1, 'Submitted', 'Applicant', 'Application submitted by applicant'),
(1, 'Under Review', 'HR Staff', 'HR started reviewing the application'),
(1, 'Shortlisted', 'HR Staff', 'Applicant passed initial screening'),
(1, 'For Interview', 'HR Staff', 'Interview scheduled'),
(1, 'For Final Review', 'HR Staff', 'Interview passed'),
(1, 'Accepted', 'HR Manager', 'Final decision: Accepted');

-- Sample Status History for Maria
INSERT INTO ApplicationStatusHistory (ApplicationID, Status, ChangedBy, Remarks) VALUES
(2, 'Draft', 'Applicant', 'Application created'),
(2, 'Submitted', 'Applicant', 'Application submitted by applicant'),
(2, 'Under Review', 'HR Staff', 'HR started reviewing'),
(2, 'Shortlisted', 'HR Staff', 'Passed screening'),
(2, 'For Interview', 'HR Staff', 'Interview scheduled');

-- Sample Status History for Pedro
INSERT INTO ApplicationStatusHistory (ApplicationID, Status, ChangedBy, Remarks) VALUES
(3, 'Draft', 'Applicant', 'Application created'),
(3, 'Submitted', 'Applicant', 'Application submitted by applicant');

-- Sample Documents
INSERT INTO ApplicantDocuments (ApplicationID, RequirementTypeID, FileName, FilePath, Status, UploadedAt) VALUES
(1, 1, 'juan_resume.pdf', 'C:/Documents/juan_resume.pdf', 'Submitted', NOW()),
(1, 2, 'juan_id.jpg', 'C:/Documents/juan_id.jpg', 'Submitted', NOW()),
(2, 1, 'maria_resume.pdf', 'C:/Documents/maria_resume.pdf', 'Submitted', NOW());

-- Sample Interview Schedule
INSERT INTO InterviewSchedules (ApplicationID, InterviewerID, ScheduledDate, Mode, Location, Status) VALUES
(2, 2, DATE_ADD(NOW(), INTERVAL 3 DAY), 'Face to Face', 'HR Office, 3rd Floor', 'Scheduled');

-- Sample Screening Results
INSERT INTO ScreeningResults (ApplicationID, ScreenedBy, Result, Remarks) VALUES
(1, 3, 'Qualified', 'Meets all qualifications for the position'),
(2, 3, 'Qualified', 'Strong candidate with relevant experience');

-- Sample Hiring Decision
INSERT INTO HiringDecisions (ApplicationID, DecidedBy, Decision, Remarks) VALUES
(1, 2, 'Accepted', 'Excellent candidate, highly recommended for the position');

-- Sample Audit Trail
INSERT INTO AuditTrail (UserType, UserID, Action, AffectedTable, AffectedID) VALUES
('HR Manager', 2, 'Final hiring decision: Accepted for ApplicationID 1', 'Applications', 1);