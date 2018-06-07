define({ "api": [
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./doc/main.js",
    "group": "D__Web_Janeto_Internship_04_2018_Sample_Code_WebApplication2_doc_main_js",
    "groupTitle": "D__Web_Janeto_Internship_04_2018_Sample_Code_WebApplication2_doc_main_js",
    "name": ""
  },
  {
    "type": "GET",
    "url": "/giangviens/GetAll",
    "title": "Lấy thông tin tất cả giảng viên",
    "group": "GiangVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"Ten\": \"Nguyen Van B\",\n     \"Ma\": \"GV-01\"\n     \n     \"Id\": 2,\n     \"Ten\": \"Nguyen Van A\",\n     \"Ma\": \"GV-01\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[        \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/GiangViensController.cs",
    "groupTitle": "GiangVien",
    "name": "GetGiangviensGetall"
  },
  {
    "type": "GET",
    "url": "/giangviens/GetById?Id=Id",
    "title": "Lấy thông tin giảng viên theo Id",
    "group": "GiangVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của giảng viên</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/api/giangviens/GetById?Id=1",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"Ten\": \"Nguyen Van A\",\n     \"Ma\": \"GV-01\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Không tìm thấy giảng viên này!\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/GiangViensController.cs",
    "groupTitle": "GiangVien",
    "name": "GetGiangviensGetbyidIdId"
  },
  {
    "type": "POST",
    "url": "/giangviens/TaoGiangVien",
    "title": "Tạo một giảng viên mới",
    "group": "GiangVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Ten",
            "description": "<p>Họ tên giảng viên</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Ma",
            "description": "<p>Mã số giảng viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     Ten: \"Nguyen Van A\",\n     Ma: \"GV-01\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của giảng viên vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Ten",
            "description": "<p>Họ tên của giảng viên vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Ma",
            "description": "<p>Mã số giảng viên vừa tạo</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": \"1\",\n     \"Ten\": \"Nguyen Van A\",\n     \"Ma\": \"GV-01\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Mã giảng viên là trường bắt buộc\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/GiangViensController.cs",
    "groupTitle": "GiangVien",
    "name": "PostGiangviensTaogiangvien"
  },
  {
    "type": "PUT",
    "url": "/giangvien/CapNhatGiangVien",
    "title": "Cập nhật thông tin một giảng viên",
    "group": "GiangVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id giảng viên cần cập nhật</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Ten",
            "description": "<p>Họ tên của giảng viên cần cập nhật</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Ma",
            "description": "<p>Mã số giảng viên của giảng viên cần cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     Id: \"1\",\n     Ten: \"Nguyen Van B\",\n     Ma: \"GV-01\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id giảng viên vừa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "H",
            "description": "<p>ọ tên của giảng viên vừa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Ma",
            "description": "<p>Mã số giảng viên của giảng viên vừa cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"Ten\": \"Nguyen Van B\",\n     \"Ma\": \"GV-01\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Không tìm thấy giảng viên có ID này\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/GiangViensController.cs",
    "groupTitle": "GiangVien",
    "name": "PutGiangvienCapnhatgiangvien"
  },
  {
    "type": "GET",
    "url": "/giangviens/GetById?Id=Id",
    "title": "Lấy thông tin lớp theo Id",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/api/giangviens/GetById?Id=1",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"TenLop\": \"CNTT\",\n     \"MaLop\": \"D14\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Không tìm thấy lớp này!\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/LopsController.cs",
    "groupTitle": "Lop",
    "name": "GetGiangviensGetbyidIdId"
  },
  {
    "type": "GET",
    "url": "/lops/GetAll",
    "title": "Lấy thông tin tất cả các lớp",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"TenLop\": \"CNTT\",\n     \"MaLop\": \"D14\"\n     \n     \"Id\": 2,\n     \"TenLop\": \"VT\",\n     \"MaLop\": \"D13\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[        \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/LopsController.cs",
    "groupTitle": "Lop",
    "name": "GetLopsGetall"
  },
  {
    "type": "POST",
    "url": "/lops/TaoLop",
    "title": "Tạo một lớp mới",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Ten",
            "description": "<p>Tên lớp</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã lớp</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     TenLop: \"CNTT\",\n     MaLop: \"D14\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Tên của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã lớp vừa tạo</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": \"1\",\n     \"TenLop\": \"CNTT\",\n     \"MaLop\": \"D14\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Mã lớp là trường bắt buộc!\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/LopsController.cs",
    "groupTitle": "Lop",
    "name": "PostLopsTaolop"
  },
  {
    "type": "PUT",
    "url": "/lops/CapNhatLop",
    "title": "Cập nhật thông tin một lớp",
    "group": "Lop",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id lớp cần cập nhật</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Tên của lớp cần cập nhật</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã lớp của lớp cần cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     Id: \"1\",\n     TenLop: \"VT\",\n     MaLop: \"D13\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id lớp vừa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TenLop",
            "description": "<p>Tên của lớp vừa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã lớp của lớp vừa cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"TenLop\": \"CNTT\",\n     \"MaLop\": \"D14\",\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Không tìm thấy lớp này!\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/LopsController.cs",
    "groupTitle": "Lop",
    "name": "PutLopsCapnhatlop"
  },
  {
    "type": "GET",
    "url": "/sinhviens/GetAll",
    "title": "Lấy thông tin tất cả sinh viên",
    "group": "SinhVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"HoTen\": \"Nguyen Van B\",\n     \"NgaySinh\": \"1991-01-01T00:00:00\",\n     \"DiaChi\": \"abc\",\n     \"MSSV\": \"N14DCCN001\"\n     \n     \"Id\": 2,\n     \"HoTen\": \"Nguyen Van A\",\n     \"NgaySinh\": \"1991-01-01T00:00:00\",\n     \"DiaChi\": \"abc\",\n     \"MSSV\": \"N14DCCN001\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[        \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/SinhViensController.cs",
    "groupTitle": "SinhVien",
    "name": "GetSinhviensGetall"
  },
  {
    "type": "GET",
    "url": "/sinhviens/GetById?Id=Id",
    "title": "Lấy thông tin sinh viên theo Id",
    "group": "SinhVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của sinh viên</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/api/sinhviens/GetById?Id=1",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"HoTen\": \"Nguyen Van B\",\n     \"NgaySinh\": \"1991-01-01T00:00:00\",\n     \"DiaChi\": \"abc\",\n     \"MSSV\": \"N14DCCN001\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Không tìm thấy sinh viên này!\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/SinhViensController.cs",
    "groupTitle": "SinhVien",
    "name": "GetSinhviensGetbyidIdId"
  },
  {
    "type": "POST",
    "url": "/sinhviens/TaoSinhVien",
    "title": "Tạo một sinh viên mới",
    "group": "SinhVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "HoTen",
            "description": "<p>Họ tên sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "DateTime",
            "optional": false,
            "field": "NgaySinh",
            "description": "<p>Ngày sinh của sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Địa chỉ của sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     HoTen: \"Nguyen Van A\",\n     NgaySinh: \"01/01/1991\",\n     DiaChi: \"abc\",\n     MSSV: \"N14DCCN001\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của sinh viên vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "HoTen",
            "description": "<p>Họ tên của sinh viên vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "DateTime",
            "optional": false,
            "field": "NgaySinh",
            "description": "<p>Ngày sinh của sinh viên vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Địa chỉ của sinh viên vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên vừa tạo</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": \"1\",\n     \"HoTen\": \"Nguyen Van A\",\n     \"NgaySinh\": \"1991-01-01T00:00:00\",\n     \"DiaChi\": \"abc\",\n     \"MSSV\": \"N14DCCN001\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"MSSV là trường bắt buộc\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/SinhViensController.cs",
    "groupTitle": "SinhVien",
    "name": "PostSinhviensTaosinhvien"
  },
  {
    "type": "PUT",
    "url": "/sinhviens/CapNhatSV",
    "title": "Cập nhật thông tin một sinh viên",
    "group": "SinhVien",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id sinh viên cần cập nhật</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "HoTen",
            "description": "<p>Họ tên của sinh viên cần cập nhật</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Điạ chỉ của sinh viên cần cập nhật</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên của sinh viên cần cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     Id: \"1\",\n     HoTen: \"Nguyen Van B\",\n     DiaChi: \"abc\",\n     MSSV: \"N14DCCN001\",\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id sinh viên vừa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "H",
            "description": "<p>ọ tên của sinh viên vừa cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Điạ chỉ của sinh viên của cập nhật</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên của sinh viên vừa cập nhật</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     \"Id\": 1,\n     \"HoTen\": \"Nguyen Van B\",\n     \"NgaySinh\": \"1991-01-01T00:00:00\",\n     \"DiaChi\": \"abc\",\n     \"MSSV\": \"N14DCCN001\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "{\n     \"Error\":[\n         \"Không tìm thấy sinh viên có ID này\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/SinhViensController.cs",
    "groupTitle": "SinhVien",
    "name": "PutSinhviensCapnhatsv"
  }
] });
