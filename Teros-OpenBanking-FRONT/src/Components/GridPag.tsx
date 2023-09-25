import React, { useState, useEffect } from "react";
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Pagination } from "@mui/material";
import GetDataService from '../Service/GetDataService.js';


function GridPag() {
  const [data, setData] = useState([]);
  const [page, setPage] = useState(1);
  const itemsPerPage = 5;
  const startIndex = (page - 1) * itemsPerPage;
  const endIndex = startIndex + itemsPerPage;
  const handleChangePage = (event: any, newPage: any) => {
    setPage(newPage);
  };

  useEffect(() => {
    const fetchDataFromApi = async () => {
      try {
        GetDataService.PostData();
      } catch (error) {
        console.error("Erro na requisição à API:", error);
      }
    };

    fetchDataFromApi();
    const intervalId = setInterval(fetchDataFromApi, 60 * 60 * 1000);

    return () => {
      clearInterval(intervalId);
    };
  }, []);

  useEffect(() => {
    var listData = GetDataService.GetAllData()
    setData(listData);
  }, [])

  return (
    <>
      <div>
        <TableContainer className="container"  component={Paper}>
          <Table>
            <TableHead className="columns">
              <TableRow>
                <TableCell>Nome</TableCell>
                <TableCell>Logo</TableCell>
                <TableCell>Discovery</TableCell>

              </TableRow>
            </TableHead>
            <TableBody>
              {data?.slice(startIndex, endIndex).map((item: any) => (
                <TableRow key={item.id}>
                  <TableCell>{item.name}</TableCell>
                  <TableCell style={{maxWidth: "40%"}} ><img height={"50%"} width={"30%"} src={item.image} alt="img not found" /></TableCell>
                  <TableCell>{item.discovery}</TableCell>
                </TableRow>
              ))}

            </TableBody>
          </Table>
        </TableContainer>
        <Pagination
          className="btn-pagination"
          count={Math.ceil(data?.length / itemsPerPage)}
          page={page}
          onChange={handleChangePage}
          variant="outlined"
          shape="rounded"
          size="large"
        />
      </div>
    </>);
}

export default GridPag;