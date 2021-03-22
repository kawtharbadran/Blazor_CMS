// JS function to popup delete confirmation modal
// source:https://www.meziantou.net/modal-component-in-blazor.htm 
function blazorInitializeModal(dialog, reference) {
    dialog.addEventListener("close", async e => {
        await reference.invokeMethodAsync("OnClose", dialog.returnValue);
    });
}

function blazorOpenModal(dialog) {
    if (!dialog.open) {
        dialog.showModal();
    }
}

function blazorCloseModal(dialog) {
    if (dialog.open) {
        dialog.close();
    }
}