using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPlanner.Models;
using MyPlanner.DAL;

namespace MyPlanner.BLL
{
    public class BLLDailyNotes
    {
        public static List<DailyNote> GetDailyNotes(int ForUserID)
        {
            return DALDailyNotes.GetDailyNotes(ForUserID);
        }

        public static DailyNote GetDailyNoteByID(int DailyNoteID)
        {
            return DALDailyNotes.GetDailyNoteByID(DailyNoteID);
        }

        public static DailyNote GetDailyNote(int ForUserID, DateTime forDate)
        {
            return DALDailyNotes.GetDailyNote(ForUserID, forDate);
        }

        public static bool UpdateDailyNote(DailyNote dailyNote)
        {
            bool returnValue = false;
            DailyNote dn = DALDailyNotes.GetDailyNote(dailyNote.ForUser.UserID, dailyNote.ForDate);
            if (dn != null)
            {
                dn.Notes = dailyNote.Notes;
                returnValue = DALDailyNotes.UpdateDailyNote(dn);
            }
            else
            {
                dn = dailyNote;
                returnValue = DALDailyNotes.AddDailyNote(dn);
            }
            return returnValue;
        }

        public static bool DeleteDailyNote(DailyNote dailyNote)
        {
            return DALDailyNotes.DeleteDailyNote(dailyNote);
        }

        public static bool DeleteDailyNote(int DailyNoteID)
        {
            return DALDailyNotes.DeleteDailyNote(DailyNoteID);
        }

        public static bool DeleteDailyNote(int ForUserID, DateTime forDate)
        {
            return DALDailyNotes.DeleteDailyNote(ForUserID, forDate);
        }
    }
}
