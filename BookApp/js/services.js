angular
  .module("bookApp.services", [])
  .service("popupService", function ($window) {
    this.showPopup = function (message) {
      return $window.confirm(message);
    };
  })
  .service("repoBook", function ($window, $http) {
    var urlBase = "https://localhost:44386/api";
    var repoBook = {};

    repoBook.getBooks = function () {
      return $http.get(urlBase + "/books");
    };

    repoBook.getBook = function (id) {
      return $http.get(urlBase + "/books/" + id);
    };
    repoBook.deleteBook = function (id) {
      return $http.delete(urlBase + "/books/" + id);
    };
    repoBook.updateBook = function (id, data) {
      return $http.put(urlBase + "/books/" + id, JSON.stringify(data));
    };
    repoBook.newBook = function (data) {
      return $http.post(urlBase + "/books", JSON.stringify(data));
    };
    return repoBook;
  });
