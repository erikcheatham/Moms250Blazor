namespace Moms250Blazor.Common;

public enum CoordinatorReportType
{
    assignmentsAToZ, //ApplicantFullName - Asc
    assignmentsByAgeBasedOnDateAssigned, //ApplicantDateAssigned - Desc
    assignmentsByStateThenAToZ, //ApplicantState Then Alpha ApplicantFullName - Asc
    assignmentsByTypeThenStatus, //AppType Then Status - Asc
    assignmentsByMailed, //Date Complete - Desc - No Selection
    assignmentsByLeadVolunteer, //FullName Lead Volunteer - Asc
    assignmentsByVolunteer, //FullName (remove managers) - Asc
    assignmentsByLastUpdate, //LastModifiedDate - Desc - No Selection
    assignmentsByMyVolunteers, //Volunteer using UserData Table For ManagerID (AspNetUserId - My ID as Person Signed In) - Asc - No Selection
    assignmentsByChapterContactList, //LastContactWithChapterDate - Desc - No Selection
}
