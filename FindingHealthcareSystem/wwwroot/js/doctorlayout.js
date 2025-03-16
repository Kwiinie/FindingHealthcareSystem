

const navLinks = document.querySelectorAll('.nav-link');
navLinks.forEach(link => {
    link.addEventListener('click', function () {
        navLinks.forEach(item => {
            item.classList.remove('active');
        })
        link.classList.add('active');
    })
})

$(document).on('click', '#nextWeekBtn', async function () {
    fetchNextWeek($('#inputDate').val(), $(this).data("next"));
})

$(document).on('change', '#inputDate', async function () {
    fetchNextWeek($(this).val(), 0);
})

async function fetchNextWeek(date, dayNext) {
    try {
        const params = new URLSearchParams({
            handler: 'NextWeek',
            monday: date,
            next: dayNext
        });
        const response = await fetch(`?${params.toString()}`, {
            method: 'GET'
        })
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.text();
        $('#patientAppointment').html(data);
    } catch (err) {
        console.log(err);
    }
}