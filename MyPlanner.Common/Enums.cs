using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyPlanner.Common
{

    #region Website Related Enums

    public enum PageMode
    {
        Add,
        Edit,
        View,
        Forward
    };

    #endregion

    #region Scheduler Related Enums

    public enum SchedRangeEndTypes
    {
        NoEndDate = 1,
        NoOfTimes = 2,
        ByEndDate = 3
    };

    public enum SchedRecurPatterns
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Yearly = 4
    };

    public enum SchedRecurPatternModes
    {
        Simple = 1,
        Advanced = 2
    };

    public enum SchedCounters
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = 5
    }

    public enum SchedDayTypes
    {
        AnyDay = 0,
        CalendarDay = 1,
        WeekDay = 2,
        WeekEndDay = 3,
        Monday = 4,
        Tuesday = 5,
        Wednesday = 6,
        Thursday = 7,
        Friday = 8,
        Saturday = 9,
        Sunday = 10
    }

    public enum SchedReminderTypes
    {
        ZeroMinutes = 1,
        FiveMinutes = 2,
        TenMinutes = 3,
        FifteenMinutes = 4,
        ThirtyMinutes = 5,
        OneHour = 6,
        TwoHours = 7,
        ThreeHours = 8
    }

    #endregion

    #region Contacts Related Enums

    public enum ContactPhoneTypes
    {
        Landline = 1,
        Mobile = 2,
        Fax = 3,
        Pager = 4,
        Others = 99
    }

    public enum ContactMessengerTypes
    {
        Skype = 1,
        GoogleTalk = 2,
        MicrosoftMessneger = 3,
        Yahoo = 4,
        AOL = 5,
        Others = 99
    }

    public enum ContactInfoTypes
    {
        Home = 1,
        Office = 2,
        AlternateHome = 3,
        AlternateOffice = 4,
        Other
    }

    public enum ContactRelations
    {
        Parent = 1,
        Spouse = 2,
        Sibiling = 3,
        Child = 4,
        Others = 99
    }

    public enum ContactEventTypes
    {
        Anniversary = 1,
        Birthday = 2,
        Others = 99
    }

    #endregion

    #region Task Related Enums

    public enum TaskPriorities
    {
        None = 0,
        A = 1,
        A1 = 2,
        A2 = 3,
        A3 = 4,
        B = 5,
        B1 = 6,
        B2 = 7,
        B3 = 8,
        C = 9,
        C1 = 10,
        C2 = 11,
        C3 = 12
    }

    public enum TaskStatuses
    {
        None = 0,
        Normal = 1,
        InProgress = 2,
        Forwarded = 3,
        Completed = 4,
        Delegated = 5,
        Deleted = 6
    }

    #endregion

    #region DataHelper Related Enums

    public enum DataSourceMode
    {
        UnKnown = 0,
        MSSQLServer = 1,
        MSSQLServerCE = 2,
        MSAccess
    }

    #endregion
}
