import React, { ReactElement, FC } from "react";
import { Box, Pagination } from "@mui/material";
import { observer } from "mobx-react-lite";
import ResourceStore from "../../stores/ResourceStore";
import ResourcesTable from "./Resource/ResourcesTable";

const store = new ResourceStore();

const Resources: FC<any> = (): ReactElement => {
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
           <ResourcesTable isLoading={store.isLoading} resources={store.resources} />
            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center'
                }}
            >
                <Pagination count={store.totalPages} page={store.currentPage} onChange={(event, page) => store.changePage(page)} />
            </Box>
        </Box>
    );
};

export default observer(Resources);
