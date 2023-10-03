import React from 'react';
import { Col, Row, Card, CardSubtitle } from 'reactstrap';

function Shield() {

    return (<>
        <Row>
            <Card>
                <CardSubtitle
                    className="mb-2 text-muted"
                    tag="h6"
                >
                    SHIELD POINTS
                </CardSubtitle>
            </Card>
        </Row>
        <Row>
        <Card>
                <CardSubtitle
                    className="mb-2 text-muted"
                    tag="h6"
                >
                    TEMPORARY SHIELD POINTS
                </CardSubtitle>
            </Card>
        </Row>
    </>);
}

export default Shield;