
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/updateHub")
    .build();

connection.on("UpdateProfessionalAppointmentInfo", function (json) {
    console.log(json.totalMyAppointment);
    $('#totalMyAppointment').text(json.totalMyAppointment);
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





