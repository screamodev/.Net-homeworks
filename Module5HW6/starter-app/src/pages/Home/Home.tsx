import React, {ReactElement, FC, useEffect, useState} from "react";
import {Box, CircularProgress, Grid, Pagination} from '@mui/material'
import * as userApi from "../../api/modules/users"
import {IUser} from "../../interfaces/users";
import UserCard from "../../components/User/UserCard";

const Home: FC<any> = (): ReactElement => {
    const [users, setUsers] = useState<IUser[] | null>(null)
    const [totalPages, setTotalPages] = useState<number>(0)
    const [currentPage, setCurrentPage] = useState<number>(1)
    const [isLoading, setIsLoading] = useState<boolean>(false)

    useEffect(() => {
        const getUser = async () => {
            try {
                setIsLoading(true)
                const res = await userApi.getByPage(currentPage)
                setUsers(res.data)
                setTotalPages(res.total_pages)
            } catch (e) {
                if (e instanceof Error) {
                    console.error(e.message)
                }
            }
            setIsLoading(false)
        }
        getUser()
    }, [currentPage])

  return (
      <Box
          sx={{
              flexGrow: 1,
              backgroundColor: "whitesmoke",
              display: "flex",
              flexDirection: "column",
              justifyContent: "center",
              alignItems: "center",
          }}>
          <Grid container spacing={4} justifyContent="center" my={4}>
              {isLoading ? (
                  <CircularProgress />
              ) : (
                  <>
                      {users?.map((item) => (
                          <Grid key={item.id} item lg={2} md={3} xs={6}>
                              <UserCard {...item} />
                          </Grid>
                      ))}
                  </>
              )}
          </Grid>
          <Box
              sx={{
                  display: 'flex',
                  justifyContent: 'center'
              }}
          >
              <Pagination count={totalPages} page={currentPage} onChange={ (event, page)=> setCurrentPage(page)} />
          </Box>
      </Box>
  );
};

export default Home;