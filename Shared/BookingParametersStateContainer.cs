namespace HotelManagementSystem.Shared
{
    public class BookingParametersStateContainer
    {
        /// <summary>
        /// State value
        /// </summary>
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// OnStateChange is an event that is raised when the Room object is modified.
        /// </summary>
        public event Action? OnStateChange;

        /// <summary>
        ///  SetValue()  sets the value of the Value property.
        /// </summary>
        /// <param name="roomValue"></param>
        public void SetValue(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate; 
            EndDate = endDate;
            NotifyStateChanged();
        }

        //NotifyStateChanged() is defined to raise the OnStateChange event.
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
