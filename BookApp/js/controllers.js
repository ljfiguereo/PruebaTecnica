angular
  .module("bookApp.controllers", [])
  .controller(
    "BookListController",
    function ($scope, $state, popupService, $window, repoBook) {
      getBooks();

      function getBooks() {
        $scope.load = true;
        repoBook
          .getBooks()
          .success(function (data) {
            $scope.books = data;
            $scope.load = false;
          })
          .error(function (error) {
            $scope.status = "Unable to load book data: " + error.message;
          });
      }
      // $scope.books = Book.query();
      $scope.loading = function () {
        if ($scope.load) return "wrapper loading";
        else return "";
      };

      $scope.deleteBook = function (id) {
        if (popupService.showPopup("Really delete this?")) {
          repoBook
            .deleteBook(id)
            .success((data) => {
              $scope.status = data;
            })
            .error(function (error) {
              $scope.status = "Unable to load book data: " + error.message;
            });
        }
      };
    }
  )
  .controller("BookViewController", function ($scope, $stateParams, repoBook) {
    // $scope.book = Book.get({ id: $stateParams.id });

    function getBook(id) {
      $scope.load = true;
      repoBook
        .getBook(id)
        .success(function (data) {
          $scope.book = data;
          $scope.load = false;
        })
        .error(function (error) {
          $scope.status = "Unable to load book data: " + error.message;
        });
    }

    getBook($stateParams.id);
  })
  .controller("BookCreateController", function ($scope, $state, repoBook) {
    $scope.book = {
      id: 0,
      title: "",
      description: "",
      pageCount: 0,
      excerpt: "",
      publishDate: "",
    };

    $scope.addBook = function (data) {
      repoBook
        .newBook(data)
        .success(function (data) {
          $state.go("books");
        })
        .error(function (error) {
          $scope.status = "Unable to load book data: " + error.message;
        });
    };
  })
  .controller(
    "BookEditController",
    function ($scope, $state, $stateParams, repoBook) {
      function getBook(id) {
        $scope.load = true;
        repoBook
          .getBook(id)
          .success(function (data) {
            $scope.book = data;
            $scope.load = false;
          })
          .error(function (error) {
            $scope.status = "Unable to load book data: " + error.message;
          });
      }

      getBook($stateParams.id);

      $scope.saveBook = function (data) {
        repoBook
          .updateBook(data.id, data)
          .success(function (data) {
            $scope.book = data;
            $scope.load = false;

            $state.go("books");
          })
          .error(function (error) {
            $scope.status = "Unable to load book data: " + error.message;
          });
      };

      // $scope.loadBook();
    }
  );
