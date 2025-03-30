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


////////////////////////////////////////////////////////////////////
///                      SIDEBAR SECTIONS                       ///
//////////////////////////////////////////////////////////////////
document.addEventListener('DOMContentLoaded', function () {
    // Toggle sidebar expand/collapse
    document.getElementById('toggleSidebar').addEventListener('click', function () {
        const sidebar = document.getElementById('sidebar');
        const mainContent = document.getElementById('mainContent');

        sidebar.classList.toggle('collapsed');
        mainContent.classList.toggle('expanded');
    });

    // Expand/collapse submenus
    const submenuToggles = document.querySelectorAll('.sidebar-link[data-bs-toggle="collapse"]');
    submenuToggles.forEach(function (toggle) {
        toggle.addEventListener('click', function () {
            // Toggle active class on the parent menu item
            this.classList.toggle('active');
        });
    });

    // Handle active state for submenu items
    const submenuLinks = document.querySelectorAll('.sidebar-submenu .sidebar-link');
    submenuLinks.forEach(function (link) {
        link.addEventListener('click', function () {
            // Remove active class from all submenu links
            submenuLinks.forEach(l => l.classList.remove('active'));

            // Add active class to clicked link
            this.classList.add('active');

            // Add active class to parent menu
            const parentCollapse = this.closest('.collapse');
            if (parentCollapse) {
                const parentToggle = document.querySelector(`[href="#${parentCollapse.id}"]`);
                if (parentToggle) {
                    parentToggle.classList.add('active');
                }
            }
        });
    });
});

    // Set active menu item based on current URL
    function setActiveMenuItem() {
        const currentPath = window.location.pathname;

        // Remove active class from all links
        document.querySelectorAll('.sidebar-link').forEach(link => {
            link.classList.remove('active');
        });

        // Find the link that matches the current path
        let activeLink = document.querySelector(`.sidebar-link[href="${currentPath}"]`);

        // If no exact match, try to find a link whose href is included in the current path
        if (!activeLink) {
            document.querySelectorAll('.sidebar-link').forEach(link => {
                const href = link.getAttribute('href');
                if (href !== '#' && href !== '/' && currentPath.includes(href)) {
                    activeLink = link;
                }
            });
        }

        // If we found an active link
        if (activeLink) {
            activeLink.classList.add('active');

            // If it's in a submenu, open the parent menu
            const parentCollapse = activeLink.closest('.collapse');
            if (parentCollapse) {
                // Show the collapse
                const bsCollapse = new bootstrap.Collapse(parentCollapse, {
                    toggle: false
                });
                bsCollapse.show();

                // Add active class to the parent menu toggle
                const parentToggle = document.querySelector(`[href="#${parentCollapse.id}"]`);
                if (parentToggle) {
                    parentToggle.classList.add('active');
                }
            }
        }
    }

    setActiveMenuItem();

    function updateTooltips() {
        const sidebar = document.getElementById('sidebar');
        const tooltipTriggerList = [].slice.call(document.querySelectorAll('.sidebar-link'));

        if (sidebar.classList.contains('collapsed')) {
            tooltipTriggerList.forEach(function (tooltipTriggerEl) {
                const text = tooltipTriggerEl.querySelector('.sidebar-text');
                if (text) {
                    tooltipTriggerEl.setAttribute('data-bs-toggle', 'tooltip');
                    tooltipTriggerEl.setAttribute('data-bs-placement', 'right');
                    tooltipTriggerEl.setAttribute('title', text.textContent.trim());

                    new bootstrap.Tooltip(tooltipTriggerEl);
                }
            });
        } else {
            tooltipTriggerList.forEach(function (tooltipTriggerEl) {
                tooltipTriggerEl.removeAttribute('data-bs-toggle');
                tooltipTriggerEl.removeAttribute('title');

                const tooltip = bootstrap.Tooltip.getInstance(tooltipTriggerEl);
                if (tooltip) {
                    tooltip.dispose();
                }
            });
        }
    }

    updateTooltips();
    document.getElementById('toggleSidebar').addEventListener('click', function () {
        setTimeout(updateTooltips, 300);
    });

    window.addEventListener('resize', function () {
        if (window.innerWidth < 992) {
            const sidebar = document.getElementById('sidebar');
            if (!sidebar.classList.contains('collapsed')) {
                sidebar.classList.add('collapsed');
                document.getElementById('mainContent').classList.add('expanded');
            }
        }

        updateTooltips();
    });
});

