function gcd(x, y) {
    while(y) {
      var t = y;
      y = x % y;
      x = t;
    }
    console.log(x);
  }

  gcd(15,5);
  gcd(2154, 458);
