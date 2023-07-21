namespace HotelManagementSystem.Shared
{
    /// <summary>
    /// Container service, to declare a Room property called Value.
    /// </summary>
    public class GlobalStateContainer
    {
        /// <summary>
        /// State value
        /// </summary>
        public DateTime? Value { get; set; }

        /// <summary>
        /// OnStateChange is an event that is raised when the Room object is modified.
        /// </summary>
        public event Action? OnStateChange;

        /// <summary>
        ///  SetValue()  sets the value of the Value property.
        /// </summary>
        /// <param name="roomValue"></param>
        public void SetValue(DateTime? value)
        {
            Value = value;
            NotifyStateChanged();
        }

        //NotifyStateChanged() is defined to raise the OnStateChange event.
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
