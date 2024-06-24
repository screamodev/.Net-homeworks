import React, {ReactElement, FC, useState, useEffect} from "react";
import {Box, Card, CardContent, CircularProgress, Grid, Pagination, Typography} from "@mui/material";
import * as resourceApi from "../../api/modules/resources";
import {IResource} from "../../interfaces/resources";
import {useNavigate} from "react-router-dom";

const Products: FC<any> = (): ReactElement => {
    const [resources, setResources] = useState<IResource[] | null>(null)
    const [totalPages, setTotalPages] = useState<number>(0)
    const [currentPage, setCurrentPage] = useState<number>(1)
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const navigate = useNavigate();
    
    useEffect(() => {
        const getResources = async () => {
            try {
                setIsLoading(true)
                const res = await resourceApi.getByPage(currentPage)
                setResources(res.data)
                setTotalPages(res.total_pages)
            } catch (e) {
                if (e instanceof Error) {
                    console.error(e.message)
                }
            }
            setIsLoading(false)
        }
        getResources()
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
      }}
    >
        <Grid container spacing={4} justifyContent="center" my={4}>
            {isLoading ? (
                <CircularProgress />
            ) : (
                <>
                    {resources?.map((item) => (
                        <Grid key={item.id} item lg={2} md={3} xs={6}>
                            <Card sx={{ minWidth: 275 }} onClick={() => navigate(`/product/${item.id}`)}>
                            <CardContent>
                                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                                    Name: {item.name}
                                </Typography>
                                <Typography variant="h5" component="div">
                                  Year: {item.year}
                                </Typography>
                                <Typography sx={{ mb: 1.5 }} color={item.color}>
                                   Color: {item.color}
                                </Typography>
                                <Typography variant="body2">
                                    Pantone value: {item.pantone_value}
                                </Typography>
                            </CardContent>
                                </Card>
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

export default Products;