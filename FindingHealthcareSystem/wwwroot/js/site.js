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
} else if (currentPage === "/blog.html") {
    document.getElementById('blog-link').classList.add('active');
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