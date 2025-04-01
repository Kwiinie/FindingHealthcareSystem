

//const editAppointment = document.getElementById('appointmentModal');
$(document).on('click', '#nextWeekBtn', function () {
    console.log("aaa");
    fetchNextWeek($('#inputDate').val(), $(this).data("next"));
});
$('#inputDate').on('change', async function () {
    fetchNextWeek($(this).val(), 0);
})

//$("#confirmDeleteModal").on("show.bs.modal", function () {
//    $("#appointmentModal").css("opacity", "0.5");
//});
//$("#confirmDeleteModal").on("hidden.bs.modal", function () {
//    $("#appointmentModal").css("opacity", "1");
//});

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
        $('#patientAppointments').html(data);
    } catch (err) {
        console.log(err);
    }
}
var deleteId = null;
var updateId = null;


function GetStatusBgColor(status) {
    var statusdiv = $('.modal-edit-status');
    switch (status) {
        case 0:
            statusdiv.css('background-color', 'rgb(255 204 0 / 20%)');
            statusdiv.css('color', 'rgb(153 123 0)');
            break;
        case 1:
            return "Đã xác nhận";
        case 2:
            return "Đang giao";
        default:
            return "Không xác định";
    }
}

function getStatusText(status) {
    switch (status) {
        case 0:
            return "Đang chờ thanh toán";
        case 1:
            return "Đã xác nhận";
        case 2:
            return "Đang giao";
        default:
            return "Không xác định";
    }
}


function openDeleteModal() {
    $('#confirmDeleteModal').modal('show');
}

$(document).on('click', '.appointment-card', function () {
    const entity = $(this).data('obj');
    console.log(entity);
    $('.patient-name').text(entity.patient?.user?.fullname);
    $('.patient-genderAge').text(entity.age + " tuổi" + " | " + entity.patient?.user?.gender);
    $('.patient-email').text(entity.patient?.user?.email);
    $('.patient-phone').text(entity.patient?.user?.phoneNumber);
    $('.modal-edit-status').text(getStatusText(entity.status));
    $('.modal-edit-date').text(new Date(entity.date).toLocaleDateString('vi-VN'));
    $('.modal-edit-hour').text(new Date(entity.date).toLocaleTimeString('vi-VN'));
    $('.notes-content').text(entity.description);

    GetStatusBgColor(entity.status);

    deleteId = entity.id;
    updateId = entity.id;

    //$('#appointmentModal').modal("show");
});
//function openAppointmentModal(entity) {

//}

$("#confirmDeleteBtn").on('click', async function () {
    await changeAppointmentStatus();
    $('#confirmDeleteModal').modal('hide');
})

async function changeAppointmentStatus() {
    try {
        const params = new URLSearchParams({
            handler: 'CancelAppointment',
            id: deleteId,
        });
        const response = await fetch(`?${params.toString()}`, {
            method: "GET"
        })
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.text();
        $('#patientAppointments').html(data);
    } catch (err) {
        console.log(err);
    }
}





