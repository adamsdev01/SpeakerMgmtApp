/* Implement one bootstrap modal across the entire application.
 * The launchModal() function takes a set of arguments and sets
 * all modals content as well as all pertinent configuration and styling settings.
 */

var appModal = $('#appModal');

function openModal(content, title, color, width, isDismissable) {
    var modalOptions = {
        cardColor: color,
        modalWidth: width,
        modalTitle: title,
        modalBodyContent: content,
        isDismissable: isDismissable
    }
    launchModal(modalOptions);
}

function closeModal() {
    appModal.modal('hide');
}

function launchModal(options) {
    setModalCardColor(options.color);
    setModalWidth(options.modalWidth);
    setModalTitle(options.modalTitle);
    setModalBody(options.modalBodyContent);

    var bootstrapModalOptions = setModalCloseButton(options.isDismissable);

    appModal.modal(bootstrapModalOptions);
}

function setModalCardColor(cardColor) {
    if (cardColor === undefined) {
        cardColor = 'primary';
    }

    var cardHeader = appModal.find('.modal-helper > .card-header');
    cardHeader.removeClass('card-header-primary card-header-info card-header-success card-header-danger card-header-warning card-header-default');
    var cardHeaderClass = 'card-header-' + cardColor;
    cardHeader.addClass(cardHeaderClass);
}

function setModalWidth(width) {
    if (width === undefined) {
        width = 'medium';
    }

    var modalDialog = appModal.find('.modal-dialog');
    modalDialog.removeClass('modal-lg modal-sm');

    if (width === 'large')
        modalDialog.addClass('modal-lg');

    if (width === 'small')
        modalDialog.addClass('modal-sm');
}

function setModalTitle(title) {
    if (title === undefined) {
        title = '';
    }
    var modalTitleDiv = appModal.find('.modal-title');
    modalTitleDiv.html(title);
}

function setModalBody(content) {
    if (content === undefined) {
        content = '';
    }
    var modalBodyDiv = appModal.find('.modal-body');
    modalBodyDiv.html(content);
}

function setModalCloseButton(isDismissable) {
    var bootstrapModalOptions = {};
    if (isDismissable === undefined || isDismissable) {
        $('#appModalCloseButton').show();
    }
    else {
        $('#appModalCloseButton').hide();
        bootstrapModalOptions.backdrop = 'static';
        bootstrapModalOptions.keyboard = false;
    }

    return bootstrapModalOptions;
}

function showErrorModal(errorMessage) {
    if (errorMessage === undefined || errorMessage === null || errorMessage === '') {
        errorMessage = 'Error.';
    }

    var modalOptions = {
        cardColor: 'danger',
        modalTitle: 'There was an error.',
        modalBodyContent: '<p class="text-center">' + errorMessage + '</p>'
    }
    launchModal(modalOptions);
}

function showInformationMessage(informationMessage, title) {
    if (title === undefined) {
        title = 'Clarification';
    }
    var modalOptions = {
        cardColor: 'info',
        modalTitle: title,
        modalBodyContent: '<p class="text-center">' + informationMessage + '</p>'
    }
    launchModal(modalOptions);
}

function centerText(text) {
    return '<p class="text-center">' + text + '</p>';
}