var app = angular.module('ProductCategories', []);

//tab controller
app.controller('TabController', function () {
    this.tab = 1;

    this.setTab = function (selectedTab) {
        this.tab = selectedTab;
    };

    this.isSet = function (givenTab) {
        return this.tab === givenTab;
    };
});

//Products Controller
app.controller('productController', function ($scope, $http) {
    var url = 'api/products';
    
    // onclick functions
    $scope.FindProducts = FindProducts;
    $scope.FindProductId = FindProductId;
    $scope.UpdateProd = UpdateProd;
    $scope.AddProd = AddProd;
    $scope.DeleteProd = DeleteProd;

    $http.get(url).success(function (response) {
        $scope.allproducts = response;
    });

    function FindProducts(category, namecategory) {
        var urlFind = url + '?' + 'idCategory=' + category + '&' + 'nameCategory=' + namecategory;
        $http.get(urlFind, {
            params: {
                idCategory: category,
                nameCategory: namecategory
            }
        }).success(function (response) {
            $scope.searchproducts = response;
        }).error(function (response) {
            $scope.searchproducts = "The products not found";
        });
    };

     function FindProductId(id) {
        $http.get(url + '/' + id, {
            params: {
                idProduct: id
            }
        }).success(function (response) {
            $scope.prodName = response.ProductName;
            $scope.categoryid = response.IdCategory;
            $scope.prodDescrpt = response.ProductDescription;
        }).error(function (response) {
            $scope.searchproducts = "The products not found";
        });
    };

    function UpdateProd(id) {
        $http.put(url + '/' + id, {
            Id: id,
            ProductName: $scope.prodName,
            IdCategory: $scope.categoryid,
            ProductDescription: $scope.prodDescrpt
        }).success(function (response) {
            sucess = "Product is updated";
            clearInputs();
        }).error(function (response) {
            $scope.searchproducts = "Not updated";
        });
    };

    function AddProd(id) {
        $http.post(url, {
            Id: id,
            ProductName: $scope.prodName,
            IdCategory: $scope.categoryid,
            ProductDescription: $scope.prodDescrpt
        }).success(function (response) {
            sucess = "Product is added";
            clearInputs()

        });
    };

    function DeleteProd(id) {
        $http.delete(url + '/' + id, {
            Id: id
        }).success(function (response) {
            sucess = "Product is deleted";
            clearInputs()
        });
    };

    function clearInputs() {
        $scope.prodName = $scope.categoryid = $scope.prodDescrpt ='';
    }
});

//categories controller
app.controller('categoryController', function ($scope, $http) {
    var url = 'api/categories';
    
    //onclick functions
    $scope.findCategoryClick = findCategoryClick;
    $scope.UpdateCategory = UpdateCategory;
    $scope.AddCategory = AddCategory;
    $scope.DeleteProd = DeleteProd;

    $http.get(url).success(function (response) {
        $scope.allpcategory = response;
    });

    function findCategoryClick(idCategory) {
        $http.get(url + '/' + idCategory).success(function (response) {
            console.log(response);
            $scope.cateforyName = response.CategoryName;
            $scope.descriptionCatgory = response.Description;
        });
    }

    function UpdateCategory (id) {
        $http.put(url + '/', {
            Id: id,
            CategoryName: $scope.cateforyName,
            Description: $scope.descriptionCatgory,
        }).success(function (response) {
            sucess = "Category is updated"
            clearInputs();
        });
    };

  function AddCategory(id) {
        $http.post(url, {
            Id: id,
            CategoryName: $scope.cateforyName,
            Description: $scope.descriptionCatgory,
        }).success(function (response) {
            sucess = "Category is added"
            clearInputs();

        });
    };

  function DeleteProd(id) {
        $http.delete(url + '/' + id, {
            Id: id
        }).success(function (response) {
            sucess = "Category is deleted"
            clearInputs();
        });
    };

    function clearInputs() {
        $scope.cateforyName = $scope.descriptionCatgory = '';
    }
});