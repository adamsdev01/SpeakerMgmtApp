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

function openEditSpeakerModal(Id) {
    $.ajax({
        type: 'GET',
        url: '/Speakers/Edit/' + Id,
        cache: false,
        async: true,
        success: function (partialView) {
            openModal(partialView, 'Edit Speaker', 'primary', 'large');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Unable to edit  Speaker  form.");
        }
    });
}
