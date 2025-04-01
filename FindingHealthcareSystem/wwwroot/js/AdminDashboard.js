document.addEventListener('DOMContentLoaded', function () {
    console.log("Tài liệu đã được tải xong");

    // Đảm bảo tất cả các thư viện được tải
    Promise.all([
        loadScript('https://cdnjs.cloudflare.com/ajax/libs/chart.js/3.9.1/chart.min.js'),
        loadScript('https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.9.4/leaflet.js'),
        loadCSS('https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.9.4/leaflet.css')
    ]).then(() => {
        console.log("Tất cả thư viện đã được tải");
        // Khởi tạo các biểu đồ
        initCharts();

        // Khởi tạo bản đồ
        initVietnamMap();
    }).catch(error => {
        console.error("Không thể tải thư viện:", error);
        showErrorMessage("Không thể tải thư viện cần thiết. Vui lòng làm mới trang hoặc kiểm tra kết nối internet.");
    });
});

// Hàm để tải script động
function loadScript(url) {
    return new Promise((resolve, reject) => {
        if (document.querySelector(`script[src="${url}"]`)) {
            resolve(); // Script đã được tải
            return;
        }

        const script = document.createElement('script');
        script.src = url;
        script.onload = resolve;
        script.onerror = reject;
        document.head.appendChild(script);
    });
}

// Hàm để tải CSS động
function loadCSS(url) {
    return new Promise((resolve, reject) => {
        if (document.querySelector(`link[href="${url}"]`)) {
            resolve(); // CSS đã được tải
            return;
        }

        const link = document.createElement('link');
        link.rel = 'stylesheet';
        link.href = url;
        link.onload = resolve;
        link.onerror = reject;
        document.head.appendChild(link);
    });
}

// Hiển thị thông báo lỗi
function showErrorMessage(message) {
    const containers = document.querySelectorAll('.chart-container, #vietnam-map');
    containers.forEach(container => {
        container.innerHTML = `<div class="alert alert-danger">${message}</div>`;
    });
}

// Khởi tạo tất cả các biểu đồ
function initCharts() {
    try {
        // Dữ liệu chung
        const months = ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6',
            'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'];

        // Khởi tạo từng biểu đồ
        initPieChart(appointmentStatusData);
        initMonthlyPaymentChart(months);
        initMonthlyAppointmentChart(months);
        initPaymentByServiceChart();
    } catch (error) {
        console.error("Lỗi khi khởi tạo biểu đồ:", error);
        showErrorMessage("Không thể khởi tạo biểu đồ. Vui lòng làm mới trang.");
    }
}

//PIE CHART
function initPieChart(statusData) {
    const pieCtx = document.getElementById('pieChart');
    if (!pieCtx) return;

    const labels = statusData.map(s => s.label);
    const data = statusData.map(s => s.count);

    new Chart(pieCtx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['#99d255', '#7da73d', '#8bc249', '#f1c40f', '#e67e22', '#e74c3c', '#b5e285', '#d2eab7'],
                borderColor: '#fff',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'right',
                }
            }
        }
    });
}


// Biểu đồ cột - Thanh toán hàng tháng
function initMonthlyPaymentChart(months) {
    const paymentCtx = document.getElementById('monthlyPaymentChart');
    if (!paymentCtx) {
        console.error("Không tìm thấy phần tử #monthlyPaymentChart");
        return;
    }

    // Tạo mảng 12 phần tử mặc định = 0
    const monthlyTotals = Array(12).fill(0);

    if (Array.isArray(monthlyPaymentData)) {
        monthlyPaymentData.forEach(item => {
            const index = item.month - 1;
            if (index >= 0 && index < 12) {
                monthlyTotals[index] = item.total;
            }
        });
    }

    new Chart(paymentCtx, {
        type: 'bar',
        data: {
            labels: months,
            datasets: [{
                label: 'Tổng Thanh Toán (Trăm VNĐ)',
                data: monthlyTotals,
                backgroundColor: '#99d255',
                borderColor: '#7da73d',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

    console.log("Biểu đồ thanh toán hàng tháng đã được khởi tạo");
}

// Biểu đồ đường - Lịch hẹn hàng tháng
function initMonthlyAppointmentChart(months) {
    const appointmentCtx = document.getElementById('monthlyAppointmentChart');
    if (!appointmentCtx) {
        console.error("Không tìm thấy phần tử #monthlyAppointmentChart");
        return;
    }

    new Chart(appointmentCtx, {
        type: 'line',
        data: {
            labels: months,
            datasets: [{
                label: 'Số Lượng Cuộc Hẹn',
                data: [240, 310, 330, 380, 400, 450, 480, 500, 520, 550, 580, 600],
                backgroundColor: 'rgba(153, 210, 85, 0.2)',
                borderColor: '#99d255',
                borderWidth: 2,
                tension: 0.3,
                fill: true
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
    console.log("Biểu đồ lịch hẹn hàng tháng đã được khởi tạo");
}

// Biểu đồ tròn - Tổng thanh toán theo loại dịch vụ
function initPaymentByServiceChart() {
    const serviceCtx = document.getElementById('paymentByServiceChart');
    if (!serviceCtx) {
        console.error("Không tìm thấy phần tử #paymentByServiceChart");
        return;
    }

    new Chart(serviceCtx, {
        type: 'doughnut',
        data: {
            labels: ['Dịch vụ công', 'Dịch vụ tư'],
            datasets: [{
                data: [35, 65],
                backgroundColor: [
                    '#99d255',
                    '#7da73d'
                ],
                borderColor: '#fff',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom',
                }
            }
        }
    });
    console.log("Biểu đồ thanh toán theo loại dịch vụ đã được khởi tạo");
}

// Dữ liệu GeoJSON cho các tỉnh thành Việt Nam
const vietnamProvinces = {
    "type": "FeatureCollection",
    "features": [
        {
            "type": "Feature",
            "properties": { "name": "Hà Nội", "facilities": 45, "doctors": 280 },
            "geometry": { "type": "Point", "coordinates": [105.8412, 21.0245] }
        },
        {
            "type": "Feature",
            "properties": { "name": "TP Hồ Chí Minh", "facilities": 56, "doctors": 350 },
            "geometry": { "type": "Point", "coordinates": [106.6297, 10.8231] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Đà Nẵng", "facilities": 22, "doctors": 130 },
            "geometry": { "type": "Point", "coordinates": [108.2022, 16.0544] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Hải Phòng", "facilities": 18, "doctors": 95 },
            "geometry": { "type": "Point", "coordinates": [106.6881, 20.8449] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Cần Thơ", "facilities": 15, "doctors": 78 },
            "geometry": { "type": "Point", "coordinates": [105.7716, 10.0341] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Nha Trang", "facilities": 14, "doctors": 72 },
            "geometry": { "type": "Point", "coordinates": [109.1967, 12.2388] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Huế", "facilities": 12, "doctors": 65 },
            "geometry": { "type": "Point", "coordinates": [107.5907, 16.4637] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Thái Nguyên", "facilities": 8, "doctors": 42 },
            "geometry": { "type": "Point", "coordinates": [105.8482, 21.5942] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Quảng Ninh", "facilities": 10, "doctors": 52 },
            "geometry": { "type": "Point", "coordinates": [107.9650, 21.0064] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Nghệ An", "facilities": 9, "doctors": 45 },
            "geometry": { "type": "Point", "coordinates": [105.6694, 19.2340] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Bình Dương", "facilities": 12, "doctors": 62 },
            "geometry": { "type": "Point", "coordinates": [106.6776, 11.3254] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Long An", "facilities": 7, "doctors": 38 },
            "geometry": { "type": "Point", "coordinates": [106.4040, 10.6956] }
        },
        {
            "type": "Feature",
            "properties": { "name": "Lâm Đồng", "facilities": 8, "doctors": 45 },
            "geometry": { "type": "Point", "coordinates": [108.1430, 11.5753] }
        }
    ]
};

// Khởi tạo bản đồ Việt Nam với Leaflet
function initVietnamMap() {
    const mapElement = document.getElementById('vietnam-map');
    if (!mapElement) {
        console.error("Không tìm thấy phần tử #vietnam-map");
        return;
    }

    console.log("Bắt đầu khởi tạo bản đồ");

    // Thêm CSS cho bản đồ nếu chưa có
    if (!document.getElementById('map-styles')) {
        const style = document.createElement('style');
        style.id = 'map-styles';
        style.textContent = `
            #vietnam-map {
                width: 100%;
                height: 500px;
                background-color: white;
                border-radius: 12px;
                box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
            }
            .info {
                padding: 6px 8px;
                font: 14px/16px 'Lexend Deca', Arial, Helvetica, sans-serif;
                background: white;
                background: rgba(255, 255, 255, 0.8);
                box-shadow: 0 0 15px rgba(0, 0, 0, 0.2);
                border-radius: 5px;
            }
            .legend {
                line-height: 18px;
                color: #555;
            }
            .legend i {
                width: 18px;
                height: 18px;
                float: left;
                margin-right: 8px;
                opacity: 0.7;
            }
        `;
        document.head.appendChild(style);
    }

    // Đảm bảo chiều cao của bản đồ
    mapElement.style.height = '500px';

    // Khởi tạo bản đồ Leaflet
    const vietnamMap = L.map('vietnam-map').setView([16.0544, 108.2022], 6);

    // Thêm lớp bản đồ OpenStreetMap
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(vietnamMap);

    // Hàm lấy màu dựa trên số lượng cơ sở y tế
    function getColor(d) {
        return d > 50 ? '#006400' :
            d > 30 ? '#1a8d1a' :
                d > 20 ? '#35b635' :
                    d > 10 ? '#51de51' :
                        d > 5 ? '#8aea8a' :
                            '#c6f6c6';
    }

    // Hàm định kiểu cho marker
    function style(feature) {
        return {
            radius: Math.sqrt(feature.properties.facilities) * 2,
            fillColor: getColor(feature.properties.facilities),
            color: "#fff",
            weight: 1,
            opacity: 1,
            fillOpacity: 0.8
        };
    }

    // Hàm thêm tương tác cho marker
    function onEachFeature(feature, layer) {
        layer.bindPopup(
            "<b>" + feature.properties.name + "</b><br>" +
            "Cơ sở y tế: " + feature.properties.facilities + "<br>" +
            "Chuyên gia y tế: " + feature.properties.doctors
        );
    }

    // Thêm dữ liệu GeoJSON vào bản đồ
    L.geoJSON(vietnamProvinces, {
        pointToLayer: function (feature, latlng) {
            return L.circleMarker(latlng, style(feature));
        },
        onEachFeature: onEachFeature
    }).addTo(vietnamMap);

    // Thêm chú thích (legend)
    const legend = L.control({ position: 'bottomright' });

    legend.onAdd = function (map) {
        const div = L.DomUtil.create('div', 'info legend');
        const grades = [0, 5, 10, 20, 30, 50];
        const labels = [];

        for (let i = 0; i < grades.length; i++) {
            const from = grades[i];
            const to = grades[i + 1];

            labels.push(
                '<i style="background:' + getColor(from + 1) + '"></i> ' +
                from + (to ? '&ndash;' + to : '+') + ' cơ sở y tế'
            );
        }

        div.innerHTML = '<h4>Số lượng cơ sở y tế</h4>' + labels.join('<br>');
        return div;
    };

    legend.addTo(vietnamMap);

    // Tự động điều chỉnh bản đồ sau khi tải xong
    setTimeout(function () {
        vietnamMap.invalidateSize();
    }, 200);

    console.log("Bản đồ đã được khởi tạo thành công");
}