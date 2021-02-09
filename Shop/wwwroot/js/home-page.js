let manMenuContainer = document.querySelector(".man-fashion .menu")
let openManMenuButton = document.querySelector(".man-fashion .menu-container button")
let closeManMenuButton = document.querySelector(".man-fashion .menu-container .close-button")

openManMenuButton.addEventListener("click", () => {
    showMenu(manMenuContainer, openManMenuButton, closeManMenuButton);
})

function showMenu(menuContainer, openMenuButton, closeMenuButton) {
    menuContainer.classList.add("menu-container-open");
    openMenuButton.classList.add("hidden");
    closeMenuButton.classList.add("animated-close-button");
}

closeManMenuButton.addEventListener("click", () => {
    hideMenu(manMenuContainer, openManMenuButton, closeManMenuButton)
})

function hideMenu(menuContainer, openMenuButton, closeMenuButton) {
    menuContainer.classList.remove("menu-container-open");
    openMenuButton.classList.remove("hidden");
    closeMenuButton.classList.remove("animated-close-button");
}


let womanMenuContainer = document.querySelector(".woman-fashion .menu")
let openWomanMenuButton = document.querySelector(".woman-fashion .menu-container button")
let closeWomanMenuButton = document.querySelector(".woman-fashion .menu-container .close-button")

openWomanMenuButton.addEventListener("click", () => {
    showMenu(womanMenuContainer, openWomanMenuButton, closeWomanMenuButton)
})

closeWomanMenuButton.addEventListener("click", () => {
    hideMenu(womanMenuContainer, openWomanMenuButton, closeWomanMenuButton)
})


