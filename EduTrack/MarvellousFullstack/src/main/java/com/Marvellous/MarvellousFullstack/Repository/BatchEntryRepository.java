package com.Marvellous.MarvellousFullstack.Repository;

import com.Marvellous.MarvellousFullstack.Entity.BatchEntry;
import org.bson.types.ObjectId;
import org.springframework.data.mongodb.repository.MongoRepository;


public interface BatchEntryRepository extends MongoRepository<BatchEntry, ObjectId>
{
}
