
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/updateHub")
    .build();

connection.on("UpdateProfessionalAppointmentInfo", function (data) {
    document.getElementById('totalMyAppointment').innerText = data.totalMyAppointment;
    document.getElementById('totalWaitAppointment').innerText = data.TotalWaitAppointment;
    document.getElementById('totalCompleteAppointment').innerText = data.totalCompleteAppointment;
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});
const navLinks = document.querySelectorAll('.nav-link');
navLinks.forEach(link => {
    link.addEventListener('click', function () {
        navLinks.forEach(item => {
            item.classList.remove('active');
        })
        link.classList.add('active');
    })
})

document.addEventListener('DOMContentLoaded', function () {
    const patientPart = $('#patientPart');
    const patientScrollTo = $('#patientRecords');
    const body = $("html, body");
    patientPart.on('click', function () {
        $(body).animate({
            scrollTop: $(patientScrollTo).offset().top
        }, 500);
    })
})




