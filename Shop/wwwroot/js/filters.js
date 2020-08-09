
document.querySelector(".show-filters-button").addEventListener("click", () => {
    toggleFiltersVisibility()
})

document.querySelector(".filters .close-button").addEventListener("click", () => {
    toggleFiltersVisibility()
})

function toggleFiltersVisibility() {
    document.querySelector(".filters").classList.toggle("filters-open")
    document.querySelector(".show-filters-button").classList.toggle("hidden");
    document.querySelector(".filters .close-button").classList.toggle("animated-close-button")
}


