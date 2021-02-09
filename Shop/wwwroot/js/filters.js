let showFiltersButton = document.querySelector(".show-filters-button");
let closeButton = document.querySelector(".filters .close-button");
let filtersContainer = document.querySelector(".filters");

showFiltersButton.addEventListener("click", () => {
    toggleFiltersVisibility()
})

closeButton.addEventListener("click", () => {
    toggleFiltersVisibility()
})

function toggleFiltersVisibility() {
    filtersContainer.classList.toggle("filters-open")
    showFiltersButton.classList.toggle("hidden");
    closeButton.classList.toggle("animated-close-button")
}


