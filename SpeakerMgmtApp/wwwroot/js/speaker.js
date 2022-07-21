$(document).ready(function () {
});

function openAddSpeakerModal() {
    $.ajax({
        type: 'GET',
        url: '/Speakers/Create',
        cache: false,
        async: true,
        success: function (partialView) {
            openModal(partialView, 'New Speaker', 'primary', 'large');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Unable to view New Speaker form.");
        }
    });
}

function openDetailSpeakerModal(Id) {
    $.ajax({
        type: 'GET',
        url: '/Speakers/Details/' + Id,
        cache: false,
        async: true,
        success: function (partialView) {
            openModal(partialView, 'Speaker Details', 'primary', 'large');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Unable to view  Speaker Details form.");
        }
    });
}
