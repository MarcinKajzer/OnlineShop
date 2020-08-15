let isOverpricedCheckbox = document.querySelector(".is-overpriced");
let newPriceInput = document.querySelector(".new-price");

function toggleDisabled() {
    if (isOverpricedCheckbox.checked == true) {
        newPriceInput.disabled = false;
    }
    else {
        newPriceInput.disabled = true;
    }
}

toggleDisabled();

isOverpricedCheckbox.addEventListener("click", () => {
    toggleDisabled();
})