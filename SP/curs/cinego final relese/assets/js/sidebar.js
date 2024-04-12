'use strict';

import { api_key, fetchDataFromServer } from "./api.js";


export function sidebar() {

  /**
   * fetch all genres eg: [ { "id": "123", "name": "Action" } ]
   * then change genre formate eg: { 123: "Action" }
   */
  const genreList = {};

  fetchDataFromServer(`http://localhost:3000/genres`, function (genres) {
    for (const { id, name } of genres) {
      genreList[id] = name;
    }

    genreLink();
  });


  const sidebarInner = document.createElement("div");
  sidebarInner.classList.add("sidebar-inner");

  sidebarInner.innerHTML = `
    <div class="sidebar-list">
    
      <p class="title">Genre</p>
    
    </div>
    
    <div class="sidebar-list">
    
      <p class="title">Movie language</p>
    
      <a href="./movie-list.html" menu-close class="sidebar-link"
        onclick='getMovieList("with_original_language=en", "English")'>English</a>
    
      <a href="./movie-list.html" menu-close class="sidebar-link"
        onclick='getMovieList("with_original_language=ru", "Russian")'>Russian</a>
    
    </div>
    
    <div class="sidebar-footer">
      <p class="copyright">
        Copyright 2023 <a href="https://www.instagram.com/aucuo/" target="_blank">aucuo</a>
      </p>
    
      <img src="./assets/images/logo.svg" width="80" alt="the movie database logo">
    </div>
  `;


  const genreLink = function () {

    for (const [genreId, genreName] of Object.entries(genreList)) {

      const link = document.createElement("a");
      link.classList.add("sidebar-link");
      link.setAttribute("href", "./movie-list.html");
      link.setAttribute("menu-close", "");
      link.setAttribute("onclick", `getMovieList("with_genres=${genreId}", "${genreName}")`);
      link.textContent = genreName;

      sidebarInner.querySelectorAll(".sidebar-list")[0].appendChild(link);

    }

    const sidebar = document.querySelector("[sidebar]");
    sidebar.appendChild(sidebarInner);
    toggleSidebar(sidebar);

  }


  const toggleSidebar = function (sidebar) {
    /**
     * Toggle sidebar in mobile screen
     */
    const sidebarMenuBtn = document.querySelector("[menu-btn]");
    const sidebarMenuTogglers = document.querySelectorAll("[menu-toggler]");
    const sidebarMenuClose = document.querySelectorAll("[menu-close]");
    const overlay = document.querySelector("[overlay]");

    addEventOnElements(sidebarMenuTogglers, "click", function () {
      sidebar.classList.toggle("active");
      sidebarMenuBtn.classList.toggle("active");
      overlay.classList.toggle("active");
    });

    addEventOnElements(sidebarMenuClose, "click", function () {
      sidebar.classList.remove("active");
      sidebarMenuBtn.classList.remove("active");
      overlay.classList.remove("active");
    });

  }

}