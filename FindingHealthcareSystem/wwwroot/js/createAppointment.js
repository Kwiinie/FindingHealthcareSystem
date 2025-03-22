////////////////////////////////////////////////////////////////////////////
///                         CALENDAR SCRIPT                             ///
//////////////////////////////////////////////////////////////////////////

const daysTag = document.querySelector(".days"),
    currentDate = document.querySelector(".current-date"),
    prevNextIcon = document.querySelectorAll(".icons span");

// getting new date, current year and month
let date = new Date(),
    currYear = date.getFullYear(),
    currMonth = date.getMonth();

let selectedDate = new Date(); // Store the selected date, default to today

// storing full name of all months in array
const months = ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7",
    "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"];

const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // getting first day of month
        lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
        lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), // getting last day of month
        lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month

    let liTag = "";

    // creating li of previous month last days
    for (let i = firstDayofMonth; i > 0; i--) {
        liTag += `<li class="inactive">${lastDateofLastMonth - i + 1}</li>`;
    }

    const today = new Date();
    today.setHours(0, 0, 0, 0); // Normalize today to start of day for comparison

    // creating li of all days of current month
    for (let i = 1; i <= lastDateofMonth; i++) {
        const currentDate = new Date(currYear, currMonth, i);
        currentDate.setHours(0, 0, 0, 0); // Normalize for comparison

        // Check if current date is before today (past date)
        const isPastDate = currentDate < today;

        // Check if this is the selected date
        const isSelectedDate = i === selectedDate.getDate() &&
            currMonth === selectedDate.getMonth() &&
            currYear === selectedDate.getFullYear();

        // adding active class to selected date, inactive to past dates
        let className = "";
        if (isSelectedDate) {
            className = "active";
        }

        if (isPastDate) {
            liTag += `<li class="inactive" style="cursor: not-allowed;">${i}</li>`;
        } else {
            liTag += `<li class="${className}" data-date="${currYear}-${currMonth + 1}-${i}" onclick="selectDate(${currYear}, ${currMonth}, ${i})">${i}</li>`;
        }
    }

    // creating li of next month first days
    for (let i = lastDayofMonth; i < 6; i++) {
        liTag += `<li class="inactive">${i - lastDayofMonth + 1}</li>`;
    }

    currentDate.innerText = `${months[currMonth]} ${currYear}`; // passing current month and year as currentDate text
    daysTag.innerHTML = liTag;
}

// Function to handle date selection
function selectDate(year, month, day) {
    const newSelectedDate = new Date(year, month, day);

    // Don't allow selecting Sundays
    if (newSelectedDate.getDay() === 0) {
        alert("Không có lịch vào Chủ nhật");
        return;
    }

    // Update the selected date
    selectedDate = newSelectedDate;

    // Rerender the calendar to show the selected date
    renderCalendar();

    // Format the date and submit the form to reload with the new date
    const formattedDate = `${year}-${month + 1}-${day}`;
    document.getElementById('SelectedDateInput').value = formattedDate;
    document.getElementById('dateSelectionForm').submit();
}

renderCalendar();

prevNextIcon.forEach(icon => { // getting prev and next icons
    icon.addEventListener("click", () => { // adding click event on both icons
        // if clicked icon is previous icon then decrement current month by 1 else increment it by 1
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if (currMonth < 0 || currMonth > 11) { // if current month is less than 0 or greater than 11
            // creating a new date of current year & month and pass it as date value
            date = new Date(currYear, currMonth, new Date().getDate());
            currYear = date.getFullYear(); // updating current year with new date year
            currMonth = date.getMonth(); // updating current month with new date month
        }

        renderCalendar(); // calling renderCalendar function
    });
});