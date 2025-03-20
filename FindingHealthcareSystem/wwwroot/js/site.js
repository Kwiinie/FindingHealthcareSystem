// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/////////////////////////////////////////////////////////////////////
///                     ACTIVE NAV-LINK                          ///
///////////////////////////////////////////////////////////////////
const currentPage = window.location.pathname;
if (currentPage === "/") {
    document.getElementById('home-link').classList.add('active');
} else if (currentPage === "/search") {
    document.getElementById('search-link').classList.add('active');
} else if (currentPage === "/search") {
    document.getElementById('appointment-link').classList.add('active');
} else if (currentPage === "/article") {
    document.getElementById('article-link').classList.add('active');
}



////////////////////////////////////////////////////////////////////
///                 LOCATION DROPDOWN SECTIONS                  ///
//////////////////////////////////////////////////////////////////
document.addEventListener('DOMContentLoaded', function () {
    toggleProviderSpecifics();

    const provinceSelect = document.getElementById('province');
    if (provinceSelect.value) {
        loadDistricts();
    }
});

function toggleProviderSpecifics() {
    const providerType = document.getElementById('providerType').value;

    document.querySelectorAll('.provider-specific').forEach(el => {
        el.classList.add('d-none');
    });

    if (providerType) {
        document.querySelectorAll(`.${providerType}-specific`).forEach(el => {
            el.classList.remove('d-none');
        });
    }
}

async function loadDistricts() {
    const provinceCode = document.getElementById('province').value;
    const districtSelect = document.getElementById('district');
    const wardSelect = document.getElementById('ward');

    districtSelect.innerHTML = '<option value="">Chọn quận/huyện</option>';
    wardSelect.innerHTML = '<option value="">Chọn phường/xã</option>';
    wardSelect.disabled = true;

    if (!provinceCode) {
        districtSelect.disabled = true;
        return;
    }

    districtSelect.disabled = false;

    try {
        const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
        let url = `?handler=Districts&provinceCode=${encodeURIComponent(provinceCode)}`;
        if (token) {
            url += `&__RequestVerificationToken=${encodeURIComponent(token)}`;
        }

        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Failed to load districts');
        }

        const districts = await response.json();

        districts.forEach(district => {
            const option = document.createElement('option');
            option.value = district.code;
            option.textContent = district.name;
            districtSelect.appendChild(option);
        });

        const urlParams = new URLSearchParams(window.location.search);
        const selectedDistrict = urlParams.get('district');
        if (selectedDistrict) {
            districtSelect.value = selectedDistrict;
            loadWards();
        }
    } catch (error) {
        console.error('Error loading districts:', error);
    }
}

async function loadWards() {
    const districtCode = document.getElementById('district').value;
    const wardSelect = document.getElementById('ward');

    wardSelect.innerHTML = '<option value="">Chọn phường/xã</option>';

    if (!districtCode) {
        wardSelect.disabled = true;
        return;
    }

    wardSelect.disabled = false;

    try {
        const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;

        let url = `?handler=Wards&districtCode=${encodeURIComponent(districtCode)}`;
        if (token) {
            url += `&__RequestVerificationToken=${encodeURIComponent(token)}`;
        }

        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Failed to load wards');
        }

        const wards = await response.json();

        wards.forEach(ward => {
            const option = document.createElement('option');
            option.value = ward.code;
            option.textContent = ward.name;
            wardSelect.appendChild(option);
        });

        const urlParams = new URLSearchParams(window.location.search);
        const selectedWard = urlParams.get('ward');
        if (selectedWard) {
            wardSelect.value = selectedWard;
        }
    } catch (error) {
        console.error('Error loading wards:', error);
    }
}



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

// storing full name of all months in array
const months = ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7",
    "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"];

const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // getting first day of month
        lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
        lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), // getting last day of month
        lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month

    let liTag = "";
    let today = new Date();
    let todayYear = today.getFullYear();
    let todayMonth = today.getMonth();
    let todayDate = today.getDate();

    // Previous month's days
    for (let i = firstDayofMonth; i > 0; i--) {
        liTag += `<li class="inactive">${lastDateofLastMonth - i + 1}</li>`;
    }

    // Current month's days
    for (let i = 1; i <= lastDateofMonth; i++) {
        let isPastDate = (currYear < todayYear || (currYear === todayYear && currMonth < todayMonth) ||
            (currYear === todayYear && currMonth === todayMonth && i < todayDate)) ? "inactive" : "";

        let isToday = (i === todayDate && currMonth === todayMonth && currYear === todayYear) ? "active" : "";

        liTag += `<li class="${isPastDate} ${isToday}" data-date="${currYear}-${currMonth + 1}-${i}">${i}</li>`;
    }

    // Next month's days
    for (let i = lastDayofMonth; i < 6; i++) {
        liTag += `<li class="inactive">${i - lastDayofMonth + 1}</li>`;
    }

    currentDate.innerText = `${months[currMonth]} ${currYear}`;
    daysTag.innerHTML = liTag;

    // Adding event listener for selecting future dates
    document.querySelectorAll(".days li:not(.inactive)").forEach(day => {
        day.addEventListener("click", function () {
            // Remove active class from all days
            document.querySelectorAll(".days li").forEach(d => d.classList.remove("active"));

            // Add active class to the clicked day
            this.classList.add("active");

            // Log selected date (for booking)
            let selectedDate = this.dataset.date;
            console.log("Selected Date: ", selectedDate);
        });
    });
}

renderCalendar();

prevNextIcon.forEach(icon => {
    icon.addEventListener("click", () => {
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;
        if (currMonth < 0 || currMonth > 11) {
            date = new Date(currYear, currMonth, new Date().getDate());
            currYear = date.getFullYear();
            currMonth = date.getMonth();
        } else {
            date = new Date();
        }
        renderCalendar();
    });
});
