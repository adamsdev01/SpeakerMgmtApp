$(document).ready(function () {
});

function openAddSpeakerModal() {
    $.ajax({
        type: 'GET',
        url: '/Speakers/Create',
        cache: false,
        async: true,
        success: function (partialView) {
            openModal(partialView, 'Speaker', 'primary', 'large');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error Message");
        }
    });
}
